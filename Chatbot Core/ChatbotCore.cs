using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using aytimothy.EIChatbot.Data;
using aytimothy.EIChatbot.Editor;

namespace aytimothy.EIChatbot
{
    public class ChatbotCore {
        public List<Dictionary> Dictionaries = new List<Dictionary>();
        public List<Intent> Intents = new List<Intent>();
        public Intent FallbackIntent;

        public ChatbotCore() {
            FallbackIntent = GenerateFallbackEvent();
        }

        public static Intent GenerateFallbackEvent() {
            Intent result = new Intent();
            result.Shapes = new Shape[0];
            result.IntentDomain = "";
            result.IntentID = "unknown";
            result.Outputs = new OutputEntity[0];
            result.GUID = "";
            return result;
        }

        public ChatbotResponse Query(ChatbotRequest request) {
            if (request.ReturnDebugInformation)
                return QueryWithDebugInfo(request);
            if (!request.ReturnDebugInformation)
                return QueryWithoutDebugInfo(request);
            throw new NotSupportedException();
        }

        public ChatbotResponse QueryWithDebugInfo(ChatbotRequest request, bool showDebugData = true) {
            ChatbotResponse response = new ChatbotResponse();
            response.UUID = EditorUtils.ByteArrayToHexString(EditorUtils.GenerateNextGUID());
            response.Request = request;
            response.PassthroughData = request.PassthroughData;
            response.Timestamp = DateTime.Now;

            List<ShapeIdentificationResult> shapeIdentificationResults = new List<ShapeIdentificationResult>();
            ShapeIdentificationResult bestIdentification = null;

            int intentIndex;
            for (intentIndex = 0; intentIndex < Intents.Count; intentIndex++) {
                Intent intent = Intents[intentIndex];
                int shapeIndex;
                for (shapeIndex = 0; shapeIndex < intent.Shapes.Length; shapeIndex++) {
                    Shape shape = intent.Shapes[shapeIndex];
                    string[] input = ProcessInput(shape.Language, request.Request);
                    ShapeIdentificationResult shapeIdentificationResult;
                    ProcessShape(input);
                    shapeIdentificationResults.Add(shapeIdentificationResult);

                    if (bestIdentification != null)
                        if (bestIdentification.Confidence > shapeIdentificationResult.Confidence)
                            bestIdentification = shapeIdentificationResult;
                    if (bestIdentification == null)
                        bestIdentification = shapeIdentificationResult;

                    string[] ProcessInput(Language language, string rawInput) {
                        switch (language) {
                            case Language.None:
                                goto case Language.English;
                            case Language.English:
                                return rawInput.Split(' ');
                            case Language.Chinese:
                                throw new NotImplementedException();
                            case Language.Japanese:
                                throw new NotImplementedException();
                            case Language.German:
                                goto case Language.English;
                            default:
                                goto case Language.English;
                        }
                    }

                    string ProcessBlock(Language language, string rawBlock) {
                        switch (language) {
                            case Language.None:
                                goto case Language.English;
                            case Language.English:
                                return Regex.Replace(rawBlock, @"[\.\,\(\)\[\]\-_\+\!\?\;]", "").ToLower();
                            case Language.Chinese:
                                throw new NotImplementedException();
                            case Language.Japanese:
                                throw new NotImplementedException();
                            case Language.German:
                                goto case Language.English;
                            default:
                                goto case Language.English;
                        }
                    }

                    void ProcessShape(string[] blockStringArray) {
                        shapeIdentificationResult = new ShapeIdentificationResult();
                        shapeIdentificationResult.IntentUUID = intent.GUID;
                        shapeIdentificationResult.ShapeUUID = shape.GUID;
                        shapeIdentificationResult.ShapeIndex = shapeIndex;
                        shapeIdentificationResult.OutputEntities = new Dictionary<string, OutputEntityResult>();
                        foreach (OutputEntity outputEntity in intent.Outputs)
                            shapeIdentificationResult.OutputEntities[outputEntity.Name] = new OutputEntityResult() {
                                HasResult = false,
                                OutputEntityName = outputEntity.Name,
                                OutputEntityUUID = outputEntity.GUID,
                                Results = new Dictionary<string, string>()
                            };

                        List<EntityIdentificationResult> entityIdentificationResults = new List<EntityIdentificationResult>();

                        int blockIndex = 0;
                        int shapeEntityIndex = 0;

                        int weighting = 0;
                        float unweightedTotalMatch = 0f;

                        while (shapeEntityIndex < shape.Entities.Length && blockIndex < blockStringArray.Length) {
                            EntityIdentificationResult entityIdentificationResult = ProcessEntity();
                            entityIdentificationResults.Add(entityIdentificationResult);

                            if (entityIdentificationResult.Success) {
                                weighting++;
                                unweightedTotalMatch += entityIdentificationResult.Match;
                            }
                            if (!entityIdentificationResult.Success) {
                                if (shape.Entities[shapeEntityIndex].Type != EntityType.Optional)
                                    weighting++;
                            }
                        }


                        shapeIdentificationResult.EntityChecks = entityIdentificationResults.ToArray();
                        shapeIdentificationResult.Confidence = unweightedTotalMatch / weighting;

                        EntityIdentificationResult ProcessEntity() {
                            EntityIdentificationResult entityIdentificationResult = new EntityIdentificationResult();
                            entityIdentificationResult.EntityIndex = shapeEntityIndex;
                            Entity currentEntity = shape.Entities[shapeEntityIndex];
                            string currentBlock = blockStringArray[blockIndex];
                            string currentBlockMatchString = ProcessBlock(shape.Language, currentBlock);
                            char[] currentEntityChars = currentEntity.RawContents.ToCharArray();
                            char[] currentBlockChars = currentBlock.ToCharArray();
                            char[] currentMatchChars = currentBlockMatchString.ToCharArray();
                            int maxIndex;
                            int longIndex;
                            int blockCharIndex;
                            int entityCharIndex;
                            int matches;
                            int altMatches;
                            int actualMatches;

                            switch (currentEntity.Type) {
                                case EntityType.None:
                                    bool isNullOrEmpty = String.IsNullOrEmpty(currentBlockMatchString);
                                    entityIdentificationResult.Match = (isNullOrEmpty) ? 1f : 0f;
                                    entityIdentificationResult.Success = isNullOrEmpty;

                                    if (entityIdentificationResult.Success) {
                                        shapeEntityIndex++;
                                    }
                                    blockIndex++;

                                    entityIdentificationResult.MatchOutput["RawContents"] = currentBlock;
                                    entityIdentificationResult.MatchOutput["Contents"] = currentBlockMatchString;
                                    break;
                                case EntityType.Optional:
                                    maxIndex = Math.Min(currentEntityChars.Length, currentMatchChars.Length);
                                    entityCharIndex = 0;
                                    for (blockCharIndex = 0; blockCharIndex < maxIndex; blockCharIndex++)
                                        if (currentEntityChars[entityCharIndex] == currentMatchChars[blockCharIndex])
                                            entityCharIndex++;
                                    matches = entityCharIndex;
                                    blockCharIndex = 0;
                                    for (entityCharIndex = 0; entityCharIndex < maxIndex; entityCharIndex++)
                                        if (currentEntityChars[entityCharIndex] == currentMatchChars[blockCharIndex])
                                            blockCharIndex++;
                                    altMatches = blockCharIndex;
                                    // todo: Try to match "escape" and "cscape", where "scape" matches...
                                    // todo: Try to match "blocks" and "blockd" where "block" matches.
                                    // todo: Try to match "achecker" and "scheckre" where "check" matches.
                                    // todo: Try to the above but with variable trailing on both sides.
                                    actualMatches = Math.Max(matches, altMatches);

                                    entityIdentificationResult.Match = actualMatches / maxIndex;
                                    entityIdentificationResult.Success = actualMatches == maxIndex;

                                    if (entityIdentificationResult.Success) {
                                        shapeEntityIndex++;
                                        blockIndex++;
                                    }
                                    if (!entityIdentificationResult.Success) {
                                        if (currentEntity.Type == EntityType.Optional)
                                            entityCharIndex++;
                                        if (currentEntity.Type != EntityType.Optional)
                                            blockIndex++;
                                    }

                                    entityIdentificationResult.MatchOutput["RawContents"] = currentBlock;
                                    entityIdentificationResult.MatchOutput["Contents"] = currentBlockMatchString;
                                    break;
                                case EntityType.PartialMatch:
                                    goto case EntityType.Optional;
                                case EntityType.DirectMatch:
                                    maxIndex = Math.Min(currentEntityChars.Length, currentBlockChars.Length);
                                    longIndex = Math.Max(currentEntityChars.Length, currentBlockChars.Length);

                                    entityCharIndex = 0;
                                    for (blockCharIndex = 0; blockCharIndex < maxIndex; blockCharIndex++)
                                        if (currentEntityChars[entityCharIndex] == currentBlockChars[blockCharIndex])
                                            entityCharIndex++;
                                    matches = entityCharIndex;
                                    blockCharIndex = 0;
                                    for (entityCharIndex = 0; entityCharIndex < maxIndex; entityCharIndex++)
                                        if (currentEntityChars[entityCharIndex] == currentBlockChars[blockCharIndex])
                                            blockCharIndex++;
                                    altMatches = blockCharIndex;

                                    actualMatches = Math.Max(matches, altMatches);
                                    entityIdentificationResult.Match = actualMatches / longIndex;
                                    entityIdentificationResult.Success = actualMatches == longIndex;

                                    if (entityIdentificationResult.Success)
                                        shapeEntityIndex++;
                                    blockIndex++;

                                    entityIdentificationResult.MatchOutput["RawContents"] = currentBlock;
                                    entityIdentificationResult.MatchOutput["Contents"] = currentBlockMatchString;
                                    break;
                                case EntityType.Match:
                                    maxIndex = Math.Min(currentEntityChars.Length, currentMatchChars.Length);
                                    longIndex = Math.Max(currentEntityChars.Length, currentMatchChars.Length);

                                    entityCharIndex = 0;
                                    for (blockCharIndex = 0; blockCharIndex < maxIndex; blockCharIndex++)
                                        if (currentEntityChars[entityCharIndex] == currentMatchChars[blockCharIndex])
                                            entityCharIndex++;
                                    matches = entityCharIndex;
                                    blockCharIndex = 0;
                                    for (entityCharIndex = 0; entityCharIndex < maxIndex; entityCharIndex++)
                                        if (currentEntityChars[entityCharIndex] == currentMatchChars[blockCharIndex])
                                            blockCharIndex++;
                                    altMatches = blockCharIndex;

                                    actualMatches = Math.Max(matches, altMatches);
                                    entityIdentificationResult.Match = actualMatches / longIndex;
                                    entityIdentificationResult.Success = actualMatches == longIndex;

                                    if (entityIdentificationResult.Success)
                                        shapeEntityIndex++;
                                    blockIndex++;

                                    entityIdentificationResult.MatchOutput["RawContents"] = currentBlock;
                                    entityIdentificationResult.MatchOutput["Contents"] = currentBlockMatchString;
                                    break;
                                case EntityType.Wildcard:
                                    entityIdentificationResult.MatchOutput["RawContents"] = currentBlock;
                                    entityIdentificationResult.MatchOutput["Contents"] = currentBlockMatchString;
                                    entityIdentificationResult.Match = 1f;
                                    entityIdentificationResult.Success = true;

                                    // todo: Multi-block length wildcards.

                                    if (shape.Entities[shapeEntityIndex].IsOutputEntity)
                                        foreach (OutputEntity outputEntity in intent.Outputs)
                                            if (outputEntity.GUID == shape.Entities[shapeEntityIndex].OutputEntityGUID) {
                                                shapeIdentificationResult.OutputEntities[outputEntity.Name].HasResult = true;
                                                shapeIdentificationResult.OutputEntities[outputEntity.Name].Results["Result"] = entityIdentificationResult.MatchOutput["RawContents"];
                                            }

                                    blockIndex++;
                                    shapeEntityIndex++;
                                    break;
                                case EntityType.DictionaryWildcard:
                                    entityIdentificationResult.Success = false;
                                    Dictionary dictionary = FindDictionary(currentEntity.RawContents);
                                    if (dictionary == null) {
                                        entityIdentificationResult.MatchOutput["RawContents"] = currentBlock;
                                        entityIdentificationResult.MatchOutput["Contents"] = currentBlockMatchString;
                                        entityIdentificationResult.MatchOutput["Vocabulary"] = "NoDictionary";
                                        entityIdentificationResult.MatchOutput["VocabularyValue"] = "NoDictionary";
                                        entityIdentificationResult.MatchOutput["VocabularyUUID"] = "NoDictionary";
                                        entityIdentificationResult.MatchOutput["VocabularyIsSynonym"] = "false";
                                        entityIdentificationResult.MatchOutput["VocabularyIndex"] = "-1";
                                        entityIdentificationResult.MatchOutput["VocabularySynonymIndex"] = "-1";
                                        entityIdentificationResult.Match = 0f;
                                        entityIdentificationResult.Success = false;
                                        blockIndex++;
                                        break;
                                    }

                                    string vocabMatchString;
                                    string[] vocabMatchStringSplit;
                                    string[] inputMatchStringSplit;
                                    float dictionaryStringMatchSuccessThreshold = 0.8f;
                                    int vocabularyIndex = -1;

                                    foreach (Vocabulary vocabulary in dictionary.Vocabulary) {
                                        vocabularyIndex++;
                                        bool breakOut = false;
                                        int synonymIndex = -1;

                                        SetupDictionaryMatchStrings(vocabulary.Meaning);
                                        DoDictionaryStringMatching();

                                        if (!breakOut) {
                                            foreach (string synonym in vocabulary.Synonyms) {
                                                synonymIndex++;
                                                SetupDictionaryMatchStrings(synonym);
                                                DoDictionaryStringMatching();
                                            }
                                        }

                                        if (breakOut)
                                            break;

                                        void SetupDictionaryMatchStrings(string vocabularyEntry) {
                                            vocabMatchString = ProcessBlock(shape.Language, vocabularyEntry);
                                            vocabMatchStringSplit = vocabMatchString.Split(' ');
                                            inputMatchStringSplit = new string[vocabMatchStringSplit.Length];
                                            for (int i = 0; i < vocabMatchStringSplit.Length; i++)
                                                if (blockIndex + i < blockStringArray.Length)
                                                    inputMatchStringSplit[i] = ProcessBlock(shape.Language, blockStringArray[blockIndex + i]);
                                        }

                                        void DoDictionaryStringMatching() {
                                            int correctMatches = 0;
                                            int _dictionaryStringMatchingIndex = 0;
                                            for (int _inputStringMatchingIndex = 0; _inputStringMatchingIndex <= vocabMatchStringSplit.Length; _inputStringMatchingIndex++)
                                                if (vocabMatchStringSplit[_dictionaryStringMatchingIndex] == inputMatchStringSplit[_inputStringMatchingIndex]) {
                                                    _dictionaryStringMatchingIndex++;
                                                    correctMatches++;
                                                }
                                            float dictionaryStringMatchness = (float)correctMatches / (float)vocabMatchStringSplit.Length;
                                            if (dictionaryStringMatchness >= dictionaryStringMatchSuccessThreshold) {
                                                breakOut = true;
                                                entityIdentificationResult.Match = dictionaryStringMatchness;
                                                entityIdentificationResult.EntityIndex = shapeEntityIndex;
                                                entityIdentificationResult.Success = true;
                                                entityIdentificationResult.MatchOutput["RawContents"] = currentBlock;
                                                entityIdentificationResult.MatchOutput["Contents"] = currentBlockMatchString;
                                                entityIdentificationResult.MatchOutput["Vocabulary"] = vocabulary.Meaning;
                                                entityIdentificationResult.MatchOutput["VocabularyValue"] = (synonymIndex >= 0) ? vocabulary.Synonyms[synonymIndex] : vocabulary.Meaning;
                                                entityIdentificationResult.MatchOutput["VocabularyUUID"] = vocabulary.GUID;
                                                entityIdentificationResult.MatchOutput["VocabularyIsSynonym"] = (synonymIndex >= 0) ? "true" : "false";
                                                entityIdentificationResult.MatchOutput["VocabularyIndex"] = vocabularyIndex.ToString();
                                                entityIdentificationResult.MatchOutput["VocabularySynonymIndex"] = synonymIndex.ToString();
                                            }
                                        }
                                    }

                                    if (!entityIdentificationResult.Success) {
                                        entityIdentificationResult.Match = 0f;
                                        entityIdentificationResult.EntityIndex = shapeEntityIndex;
                                        entityIdentificationResult.MatchOutput["RawContents"] = currentBlock;
                                        entityIdentificationResult.MatchOutput["Contents"] = currentBlockMatchString;
                                        entityIdentificationResult.Success = false;

                                        if (shape.Entities[shapeEntityIndex].IsOutputEntity)
                                            foreach (OutputEntity outputEntity in intent.Outputs)
                                                if (outputEntity.GUID == shape.Entities[shapeEntityIndex].OutputEntityGUID) {
                                                    shapeIdentificationResult.OutputEntities[outputEntity.Name].HasResult = true;
                                                    shapeIdentificationResult.OutputEntities[outputEntity.Name].Results["Result"] = entityIdentificationResult.MatchOutput["RawContents"];
                                                    shapeIdentificationResult.OutputEntities[outputEntity.Name].Results["VocabularyGUID"] = entityIdentificationResult.MatchOutput["VocabularyUUID"];
                                                }
                                    }
                                    if (entityIdentificationResult.Success)
                                        shapeEntityIndex++;
                                    blockIndex++;

                                    break;
                                case EntityType.SpecialWildcard:
                                    entityIdentificationResult.MatchOutput["RawContents"] = currentBlock;
                                    entityIdentificationResult.MatchOutput["Contents"] = currentBlockMatchString;

                                    switch (currentEntity.RawContents) {
                                        case "S:NONE":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.None).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "NONE";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "None";
                                            break;
                                        case "S:DATE":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.Date).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "DATE";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Date";
                                            break;
                                        case "S:DTIN":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.DateInterval).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "DTIN";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Date Interval";
                                            break;
                                        case "S:TIME":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.Time).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "TIME";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Time";
                                            break;
                                        case "S:DTTI":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.TimeInterval).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "DTIN";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Time Interval";
                                            break;
                                        case "S:TISP":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.TimeSpan).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "TISP";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Time Span";
                                            break;
                                        case "S:NUMB":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.Number).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "NUMB";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Any Number";
                                            break;
                                        case "S:ORDI":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.Ordinal).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "ORDI";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Ordinal Number";
                                            break;
                                        case "S:INTR":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.Integer).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "INTR";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Integer Number (includes negatives)";
                                            break;
                                        case "S:NUSQ":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.NumberSequence).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "NUSQ";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Number Sequence";
                                            break;
                                        case "S:FLUN":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.FlightNumber).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "FLUN";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Flight Number";
                                            break;
                                        case "S:ANUN":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.AnyUnit).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "ANUN";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Any Unit";
                                            break;
                                        case "S:ARUN":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.AreaUnit).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "ARUN";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Area Unit";
                                            break;
                                        case "S:CUUN":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.CurrencyUnit).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "CUUN";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Currency Unit";
                                            break;
                                        case "S:LGUN":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.LengthUnit).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "LGUN";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Length Unit";
                                            break;
                                        case "S:SPUN":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.SpeedUnit).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "SPUN";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Speed Unit";
                                            break;
                                        case "S:VLUN":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.VolumeUnit).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "VLUN";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Volume Unit";
                                            break;
                                        case "S:WTUN":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.WeightUnit).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "WTUN";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Weight Unit";
                                            break;
                                        case "S:INUN":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.InformationUnit).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "INUN";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Information/Data Unit";
                                            break;
                                        case "S:TMUN":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.TemperatureUnit).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "TMUN";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Temperature Unit";
                                            break;
                                        case "S:DRUN":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.DurationUnit).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "DRUN";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Duration Unit";
                                            break;
                                        case "S:AGUN":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.AgeUnit).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "AGUN";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Age Unit";
                                            break;
                                        case "S:CUNM":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.CurrencyName).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "CUNM";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Currency Name";
                                            break;
                                        case "S:UNNM":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.UnitName).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "UNNM";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Unit Name";
                                            break;
                                        case "S:ADDR":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.Address).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "ADDR";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Street Address";
                                            break;
                                        case "S:STAD":
                                            // Alias of ADDR.
                                            goto case "S:ADDR";
                                        case "S:ZIPC":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.ZIPCode).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "ZIPC";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Postal (ZIP) Code";
                                            break;
                                        case "S:COUN":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.Country).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "COUN";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Country Name";
                                            break;
                                        case "S:CITY":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.City).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "CITY";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "City Name";
                                            break;
                                        case "S:DIST":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.District).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "DIST";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "District Name";
                                            break;
                                        case "S:COCO":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.CountryCode).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "COCO";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Country Code";
                                            break;
                                        case "S:LANG":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.Language).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "LANG";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Language";
                                            break;
                                        case "S:LACO":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.LanguageCode).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "LACO";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Language Code";
                                            break;
                                        case "S:AIRP":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.Airport).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "AIRP";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Airport Code/Name";
                                            break;
                                        case "S:CORD":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.Coordinate).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "CORD";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Coordinate";
                                            break;
                                        case "S:COSC":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.CoordinateShortcode).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "COSC";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Coordinate Shortcode";
                                            break;
                                        case "S:MAIL":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.Email).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "MAIL";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Email Address";
                                            break;
                                        case "S:PHNU":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.PhoneNumber).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "PHNU";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Phone Number";
                                            break;
                                        case "S:COLO":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.Color).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "COLO";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Color";
                                            break;
                                        case "S:WURL":
                                            entityIdentificationResult.MatchOutput["SpecialWildcardID"] = ((int)SpecialWildcardType.URL).ToString();
                                            entityIdentificationResult.MatchOutput["SpecialWildcardCode"] = "WURL";
                                            entityIdentificationResult.MatchOutput["SpecialWildcardType"] = "Web URL/Address";
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                            return entityIdentificationResult;
                        }
                    }
                }
            }

            float minimumSuccessConfidence = 0.8f;
            if (bestIdentification.Confidence >= minimumSuccessConfidence) {
                Intent bestIntent = FindIntent(bestIdentification.IntentUUID);
                response.Output = bestIdentification.OutputEntities;
                response.Confidence = bestIdentification.Confidence;
                response.Intent = bestIntent.IntentFullID;
                response.Response = bestIntent.IntentFullID;
                response.ShapeUUID = bestIdentification.ShapeUUID;
                response.IntentUUID = bestIdentification.IntentUUID;
            }
            if (bestIdentification.Confidence < minimumSuccessConfidence) {
                response.Output = null;
                response.Confidence = 1f;
                response.Intent = FallbackIntent.IntentFullID;
                response.Response = FallbackIntent.IntentFullID;
                response.ShapeUUID = "";
                response.IntentUUID = "";
            }
            response.DebugInformation = new ChatbotDebugInformation();
            response.DebugInformation.ShapeIdentificationResults = shapeIdentificationResults.ToArray();
            response.ProcessingTime = DateTime.Now - response.Timestamp;
            return response;
        }

        public ChatbotResponse QueryWithoutDebugInfo(ChatbotRequest request) {
            // todo: Splice debug stuff out of the algorithm above.
            return QueryWithDebugInfo(request);
        }

        public Dictionary FindDictionary(string UUID) {
            for (int dictIndex = 0; dictIndex < Dictionaries.Count; dictIndex++)
                if (Dictionaries[dictIndex].GUID == UUID)
                    return Dictionaries[dictIndex];
            return null;
        }

        public bool DictionaryContains(Dictionary Dictionary, string Word) {
            foreach (Vocabulary vocabulary in Dictionary.Vocabulary) {
                if (vocabulary.Meaning == Word)
                    return true;
                foreach (string synonym in vocabulary.Synonyms)
                    if (synonym == Word)
                        return true;
                return false;
            }
            return false;
        }

        public Intent FindIntent(string UUID) {
            for (int intentIndex = 0; intentIndex < Intents.Count; intentIndex++)
                if (Intents[intentIndex].GUID == UUID)
                    return Intents[intentIndex];
            return null;
        }

        public Shape FindShape(string UUID) {
            foreach (Intent intent in Intents)
                foreach (Shape shape in intent.Shapes)
                    if (shape.GUID == UUID)
                        return shape;
            return null;
        }

        public Vocabulary FindVocabulary(string UUID) {
            for (int dictIndex = 0; dictIndex < Dictionaries.Count; dictIndex++)
                for (int vocabIndex = 0; vocabIndex < Dictionaries[dictIndex].Vocabulary.Length; vocabIndex++)
                    if (Dictionaries[dictIndex].Vocabulary[vocabIndex].GUID == UUID)
                        return Dictionaries[dictIndex].Vocabulary[vocabIndex];
            return null;
        }

        public Vocabulary FindVocabularyWith(string Word) {
            string word = Regex.Replace(Word, "[!?\\-,.\\(\\)\\[\\]_ ]", "").ToLower();
            foreach (Dictionary dictionary in Dictionaries)
                foreach (Vocabulary vocabulary in dictionary.Vocabulary) {
                    if (Regex.Replace(vocabulary.Meaning, "[!?\\-,.\\(\\)\\[\\]_ ]", "").ToLower() == word)
                        return vocabulary;
                    foreach (string synonym in vocabulary.Synonyms)
                        if (Regex.Replace(synonym, "[!?\\-,.\\(\\)\\[\\]_ ]", "").ToLower() == word)
                            return vocabulary;
                }
            return null;
        }
    }
}
