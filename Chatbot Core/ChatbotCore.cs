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

        public ChatbotResponse Query(ChatbotRequest request) {
            if (request.ReturnDebugInformation)
                return QueryWithDebugInfo(request);
            if (!request.ReturnDebugInformation)
                return QueryWithoutDebugInfo(request);
            throw new NotSupportedException();
        }

        public ChatbotResponse QueryWithDebugInfo(ChatbotRequest request, bool showDebugData = true) {
            //ChatbotResponse response = new ChatbotResponse();
            //if (showDebugData)
            //    response.DebugInformation = new ChatbotDebugInformation();
            //response.PassthroughData = request.PassthroughData;
            //response.Timestamp = DateTime.Now;

            //DateTime startTime = DateTime.Now;
            
            //List<ShapeIdentificationResult> shapeDebugInformation = new List<ShapeIdentificationResult>();
            //foreach (Intent intent in Intents) {
            //    for (int i = 0; i < intent.Shapes.Length; i++) {
            //        ShapeIdentificationResult shapeIDResult = Evaluate(intent, i, request.Request);
            //    }
            //}

            //return response;

            //ShapeIdentificationResult Evaluate(Intent intent, int shapeIndex, string requestString) {
            //    ShapeIdentificationResult shapeIdentificationResult = new ShapeIdentificationResult();
            //    shapeIdentificationResult.IntentUUID = intent.GUID;
            //    shapeIdentificationResult.ShapeUUID = intent.Shapes[shapeIndex].GUID;
            //    shapeIdentificationResult.ShapeIndex = shapeIndex;
                
            //    Dictionary<string, OutputEntityResult> outputEntityResults = new Dictionary<string, OutputEntityResult>();
            //    string[] splitString = requestString.Split(' ');

            //    List<EntityIdentificationResult> directMatchEntityIdentificationResults = new List<EntityIdentificationResult>();

            //    int maxBlockIndex = Math.Min(intent.Shapes[shapeIndex].Entities.Length, splitString.Length);
            //    float directMatchApproachConfidence = 0f;
            //    for (int i = 0; i < maxBlockIndex; i++) {
            //        EntityIdentificationResult entityIdentificationResult = Compare(intent.Shapes[shapeIndex].Language, intent.Shapes[shapeIndex].Entities[i], i, splitString[i]);

            //        // do confidence calculation

            //        directMatchEntityIdentificationResults.Add(entityIdentificationResult);
            //    }

            //    List<EntityIdentificationResult> delayedStartEntityIdentificationResults = new List<EntityIdentificationResult>();
            //    float delayedStartApproachConfidence = 0f;
            //    if (intent.Shapes[shapeIndex].Entities.Length != splitString.Length) {
            //        int offset = 0;
            //        for (int i = 0; i < maxBlockIndex; i++) {
            //            EntityIdentificationResult entityIdentificationResult = Compare(intent.Shapes[shapeIndex].Language, intent.Shapes[shapeIndex].Entities[i], i, splitString[i + offset]);
                        
            //            if (!entityIdentificationResult.Success && i == 0) {
            //                i--;
            //                offset++;
            //                continue;
            //            }

            //            // do confidence calculation

            //            directMatchEntityIdentificationResults.Add(entityIdentificationResult);
            //        }
            //    }

            //    bool useDelayedStartApproach = delayedStartApproachConfidence > directMatchApproachConfidence;
            //    shapeIdentificationResult.Confidence = (useDelayedStartApproach) ? delayedStartApproachConfidence : directMatchApproachConfidence;
            //    shapeIdentificationResult.Result = (shapeIdentificationResult.Confidence >= 0.8f) ? ShapeIdentificationStatus.SuccessMatch : ShapeIdentificationStatus.SuccessNoMatch;
            //    shapeIdentificationResult.EntityChecks = (useDelayedStartApproach) ? delayedStartEntityIdentificationResults.ToArray() : directMatchEntityIdentificationResults.ToArray();
            //    return shapeIdentificationResult;
            //}

            //EntityIdentificationResult Compare (Language language, Entity entity, int entityIndex, string block) {
            //    EntityIdentificationResult entityIdentificationResult = new EntityIdentificationResult();
            //    entityIdentificationResult.EntityIndex = entityIndex;
            //    entityIdentificationResult.MatchOutput = new Dictionary<string, string>();

            //    string matchBlock = "";
            //    string matchEntity = "";
            //    switch (language) {
            //        case Language.None:
            //            matchBlock = ConvertToMatchString(Language.None, block);
            //            matchEntity = ConvertToMatchString(Language.None, entity.RawContents);
            //            break;
            //        case Language.English:
            //            matchBlock = ConvertToMatchString(Language.English, block);
            //            matchEntity = ConvertToMatchString(Language.English, entity.RawContents);
            //            break;
            //        case Language.Chinese:
            //            matchBlock = ConvertToMatchString(Language.Chinese, block);
            //            matchEntity = ConvertToMatchString(Language.Chinese, entity.RawContents);
            //            break;
            //        case Language.Japanese:
            //            matchBlock = ConvertToMatchString(Language.Japanese, block);
            //            matchEntity = ConvertToMatchString(Language.Japanese, entity.RawContents);
            //            break;
            //        case Language.German:
            //            matchBlock = ConvertToMatchString(Language.German, block);
            //            matchEntity = ConvertToMatchString(Language.German, entity.RawContents);
            //            break;
            //        default:
            //            throw new NotSupportedException("The specified language does not exist, or is not supported.");
            //    }

            //    char[] matchBlockChars;
            //    char[] matchEntityChars;
            //    int maxIndex = 0;
            //    int maxLength = 0;
            //    int matchPointer = 0;

            //    switch (entity.Type) {
            //        case EntityType.None:
            //            if (String.IsNullOrEmpty(block)) {
            //                entityIdentificationResult.Match = 1f;
            //                entityIdentificationResult.Success = true;
            //            }
            //            if (!String.IsNullOrEmpty(block)) {
            //                entityIdentificationResult.Match = 0f;
            //                entityIdentificationResult.Success = true;
            //            }
            //            break;
            //        case EntityType.Optional:
            //            goto case EntityType.Match;
            //        case EntityType.PartialMatch:
            //            matchBlockChars = matchBlock.ToCharArray();
            //            matchEntityChars = matchEntity.ToCharArray();
            //            maxIndex = Math.Min(matchBlockChars.Length, matchEntityChars.Length);
            //            for (int i = 0; i < maxIndex; i++)
            //                if (matchBlockChars[i] == matchEntityChars[matchPointer])
            //                    matchPointer++;
            //            entityIdentificationResult.Match = matchPointer / maxIndex;
            //            entityIdentificationResult.Success = matchPointer == maxIndex;
            //            break;
            //        case EntityType.DirectMatch:
            //            matchBlockChars = block.ToCharArray();
            //            matchEntityChars = entity.SourceString.ToCharArray();
            //            maxIndex = Math.Min(matchBlockChars.Length, matchEntityChars.Length);
            //            maxLength = Math.Max(matchBlockChars.Length, matchEntityChars.Length);
            //            for (int i = 0; i < maxIndex; i++)
            //                if (matchBlockChars[i] == matchEntityChars[matchPointer])
            //                    matchPointer++;
            //            entityIdentificationResult.Match = matchPointer / maxLength;
            //            entityIdentificationResult.Success = matchPointer == maxLength;
            //            break;
            //        case EntityType.Match:
            //            matchBlockChars = matchBlock.ToCharArray();
            //            matchEntityChars = matchEntity.ToCharArray();
            //            maxIndex = Math.Min(matchBlockChars.Length, matchEntityChars.Length);
            //            maxLength = Math.Max(matchBlockChars.Length, matchEntityChars.Length);
            //            for (int i = 0; i < maxIndex; i++)
            //                if (matchBlockChars[i] == matchEntityChars[matchPointer])
            //                    matchPointer++;
            //            entityIdentificationResult.Match = matchPointer / maxLength;
            //            entityIdentificationResult.Success = matchPointer == maxLength;
            //            break;
            //        case EntityType.Wildcard:
            //            if (String.IsNullOrEmpty(block)) {
            //                entityIdentificationResult.Match = 0f;
            //                entityIdentificationResult.Success = false;
            //            }
            //            if (!String.IsNullOrEmpty(block)) {
            //                entityIdentificationResult.Match = 1f;
            //                entityIdentificationResult.Success = true;
            //            }
            //            break;
            //        case EntityType.DictionaryWildcard:
            //            Dictionary dictionary = FindDictionary(entity.RawContents);
            //            foreach (Vocabulary vocabulary in dictionary.Vocabulary) {
            //                string matchMeaning = ConvertToMatchString(language, vocabulary.Meaning);
            //                if (matchBlock == matchMeaning) {
            //                    entityIdentificationResult.Match = 1f;
            //                    entityIdentificationResult.Success = true;
            //                    entityIdentificationResult.MatchOutput["VocabularyGUID"] = vocabulary.GUID;
            //                    entityIdentificationResult.MatchOutput["Vocabulary"] = vocabulary.Meaning;
            //                    break;
            //                }

            //                foreach (string synonym in vocabulary.Synonyms) {
            //                    string matchSynonym = ConvertToMatchString(language, synonym);
            //                    if (matchBlock == matchSynonym) {
            //                        entityIdentificationResult.Match = 1f;
            //                        entityIdentificationResult.Success = true;
            //                        entityIdentificationResult.MatchOutput["VocabularyGUID"] = vocabulary.GUID;
            //                        entityIdentificationResult.MatchOutput["Vocabulary"] = vocabulary.Meaning;
            //                        break;
            //                    }
            //                }

            //                entityIdentificationResult.Match = 0f;
            //                entityIdentificationResult.Success = false;
            //            }
            //            break;
            //        case EntityType.SpecialWildcard:
            //            switch (entity.RawContents) {
            //                case "S:NONE":
            //                    entityIdentificationResult.MatchOutput["Type"] = "None";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.None).ToString();
            //                    break;
            //                case "S:DATE":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Date";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.Date).ToString();
            //                    break;
            //                case "S:DTIN":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Date Interval";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.DateInterval).ToString();
            //                    break;
            //                case "S:TIME":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Time";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.Time).ToString();
            //                    break;
            //                case "S:TIIN":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Time Interval";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.TimeInterval).ToString();
            //                    break;
            //                case "S:DTTI":
            //                    entityIdentificationResult.MatchOutput["Type"] = "DateTime";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.DateTime).ToString();
            //                    break;
            //                case "S:TISP":
            //                    entityIdentificationResult.MatchOutput["Type"] = "DateTime Interval (TimeSpan)";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.TimeSpan).ToString();
            //                    break;
            //                case "S:NUMB":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Any Number";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.Number).ToString();
            //                    break;
            //                case "S:ORDI":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Ordinal";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.Ordinal).ToString();
            //                    break;
            //                case "S:INTR":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Integer";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.Integer).ToString();
            //                    break;
            //                case "S:NUSQ":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Number Sequence";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.NumberSequence).ToString();
            //                    break;
            //                case "S:FLNU":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Flight Number";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.FlightNumber).ToString();
            //                    break;
            //                case "S:ANUN":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Area Unit";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.AreaUnit).ToString();
            //                    break;
            //                case "S:CUUN":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Currency Unit";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.CurrencyUnit).ToString();
            //                    break;
            //                case "S:LGUN":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Length Unit";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.LengthUnit).ToString();
            //                    break;
            //                case "S:SPUN":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Speed Unit";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.SpeedUnit).ToString();
            //                    break;
            //                case "S:VLUN":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Volume Unit";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.VolumeUnit).ToString();
            //                    break;
            //                case "S:WTUN":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Weight Unit";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.WeightUnit).ToString();
            //                    break;
            //                case "S:INUN":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Information Unit";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.InformationUnit).ToString();
            //                    break;
            //                case "S:TMUN":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Temperature Unit";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.TemperatureUnit).ToString();
            //                    break;
            //                case "S:DRUN":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Duration Unit";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.DurationUnit).ToString();
            //                    break;
            //                case "S:AGUN":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Age Unit";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.AgeUnit).ToString();
            //                    break;
            //                case "S:CUNM":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Currency Name";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.CurrencyName).ToString();
            //                    break;
            //                case "S:UNNM":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Unit Name";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.UnitName).ToString();
            //                    break;
            //                case "S:ADDR":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Address";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.Address).ToString();
            //                    break;
            //                case "S:STAD":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Street Address";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.StreetAddress).ToString();
            //                    break;
            //                case "S:ZIPC":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Postal Code (ZIP Code)";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.ZIPCode).ToString();
            //                    break;
            //                case "S:COUN":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Country";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.Country).ToString();
            //                    break;
            //                case "S:CITY":
            //                    entityIdentificationResult.MatchOutput["Type"] = "City";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.City).ToString();
            //                    break;
            //                case "S:DIST":
            //                    entityIdentificationResult.MatchOutput["Type"] = "District";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.District).ToString();
            //                    break;
            //                case "S:COCO":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Country Code";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.CountryCode).ToString();
            //                    break;
            //                case "S:LANG":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Language";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.Language).ToString();
            //                    break;
            //                case "S:LACO":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Language Code";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.LanguageCode).ToString();
            //                    break;
            //                case "S:AIRP":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Airport";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.Airport).ToString();
            //                    break;
            //                case "S:CORD":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Coordinate";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.Coordinate).ToString();
            //                    break;
            //                case "S:COSC":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Coordinate Shortcode";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.CoordinateShortcode).ToString();
            //                    break;
            //                case "S:MAIL":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Email";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.Email).ToString();
            //                    break;
            //                case "S:PHNU":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Phone Number";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.PhoneNumber).ToString();
            //                    break;
            //                case "S:COLO":
            //                    entityIdentificationResult.MatchOutput["Type"] = "Color";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.Color).ToString();
            //                    break;
            //                case "S:WURL":
            //                    entityIdentificationResult.MatchOutput["Type"] = "URL";
            //                    entityIdentificationResult.MatchOutput["TypeID"] = ((int)SpecialWildcardType.URL).ToString();
            //                    break;
            //            }
            //            break;
            //        default:
            //            throw new ArgumentOutOfRangeException();
            //    }

            //    return entityIdentificationResult;
            //}

            //string ConvertToMatchString(Language language, string block) {
            //    switch (language) {
            //        case Language.None:
            //            return "";
            //        case Language.English:
            //            return Regex.Replace(block, "[!?\\-,.\\(\\)\\[\\]_ ]", "").ToLower();
            //        case Language.Chinese:
            //            return block;
            //        case Language.Japanese:
            //            throw new NotImplementedException();
            //        case Language.German:
            //            return Regex.Replace(block, "[!?\\-,.\\(\\)\\[\\]_ ]", "").ToLower();
            //        default:
            //            throw new NotImplementedException();
            //    }
            //}
            throw new NotImplementedException("// todo: Restructure code so that it makes sense in the context that the inner functions can push forward/back a block (because some entities can be multi-block).");
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
            bool broken = false;
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
