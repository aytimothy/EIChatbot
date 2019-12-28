# EIChatbot
A .NET Framework Entity-Intent Natural Language Parser (AKA. Chatbot)

Includes its own editor, client and library.

## How to use

* To use the chatbot in your own program, just build, link or copy the files in the `Chatbot Core` project into your other project.
* To use the editor, download or build `Editor`.

## Concepts

* Special words are known as `Vocabulary`, stored in `Dictionary` (not to be confused with the `Dictionary<T, T>` data structure).
* The words and phrases you want your chatbot to understand are `Intent`, which have different `Shape` (different ways to say X).
* A `Shape` is comprised of `Entity`-ies, which are basically word/phrase building blocks.

## Where's the intelligence?

There isn't one. This is a dumb pattern matcher. It's what number of patterns you specify is where it gets smart.  
I did add (or am working on) code to help automate the creation of the `Shape` patterns though.
