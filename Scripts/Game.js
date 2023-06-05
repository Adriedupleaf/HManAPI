﻿// this is a javascript comment, the double slash turns one line into a comment
/* 
the slash and * are used for multiline comments
anything you write between them will not be used as code
Below I have writen comments to try and explain what the following bits of code do
read them to understand what the code does and how it may be alterted.
*/

// varible declarations
var words = [
    "Minecraft",
    "Player",
    "Zombie",
    "Leader",
    "Engaged",
    "DungeonMaster",
    "Analog",
    "Experience",
    "Server",
    "Unplugged",
    "YouTube",
    "Games",
    "Exercise",
    "Business",
    "Student Lead",
    "Focus",
    "Sandbox",
    "Device",
    "Civilisation",
    "Strategy",
    "Esports",
    "AmongUs"
]; // change this list to change the words used.
var theWord = words[Math.floor(Math.random() * words.length)].toLowerCase(); // choose random word, make lowercase.
// match html elements to varibles for ease.
var dashes = document.querySelector("#dashes");
var guesses = document.querySelector("#guesses");
var guessed = document.querySelector("#guessed");
const input = document.querySelector("input");
var count = 0; // count number of incorrect guesses
var used = []; //list of guessed letters

//initial loop for dashes
for (var i = 0; i < theWord.length; i++) {
    dashes.innerHTML += "_ ";
}
// fancy way would be: dashes.innerHTML = "_ ".repeat(theWord.length);

// do something when user types a letter, input is restricted to a-z charset
input.addEventListener("input", userGuess);

//function that is called when a letter is typed
function userGuess(e) {
    document.querySelector("#won").innerHTML = "";
    if (used.includes(e.target.value)) {
        // user has guessed that letter already
        document.querySelector("#won").innerHTML =
            "You have guessed that letter already";
        e.target.value = ""; //emtpy input box
    } else {
        used.push(e.target.value.toLowerCase()); // add letter to used letters list - does not check if it is there already
        guessed.innerHTML += e.target.value + " "; // adds to list of letters used on screen
        dashes.innerHTML = "";
        // blank out dashes
        // loop through each letter in theWord and print a dash or the letter if it in in used list
        var won = true;
        for (var i = 0; i < theWord.length; i++) {
            if (used.includes(theWord[i])) {
                dashes.innerHTML += theWord[i] + " ";
            } else {
                dashes.innerHTML += "_ ";
                won = false;
            }
        }

        if (!theWord.includes(e.target.value)) {
            count++; // keep count of incorrect guesses
            guesses.innerHTML = count;
        }
        e.target.value = ""; //emtpy input box

        //check if the play has won

        if (won) {
            document.querySelector("#won").innerHTML = "You Won!";
            //input.removeEventListener("input", userGuess);
            setTimeout(function () {
                console.log("game over");
            }, 3000);
        }
        //check if the player has used more than 12 guesses. does not force game refresh
        if (count > 12) {
            document.querySelector("#won").innerHTML = "You lost!";
        }
    }
}
