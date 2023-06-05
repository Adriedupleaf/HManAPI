//const auth = firebase.auth();
//const ResetPasswordFunction = () => {
//    const emailAddress = document.getElementById("emailAddress").value;
//    auth.sendPasswordResetEmail(emailAddress).then(() => {
//            console.log("Email sent");
//        })
//        .catch((error) => {
//            console.log(error);
//        })
//})

//ResetPasswordFunction.AddEventListener("click", (event) => {
//    ResetPasswordFunction();
//});



//import { initializeApp } from "Firebase.auth/app";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
    apiKey: "AIzaSyD797F3YmgHaOzJj2hlBs9ZHFDxdUefatU",
    authDomain: "hman-ram212.firebaseapp.com",
    databaseURL: "https://hman-ram212-default-rtdb.europe-west1.firebasedatabase.app",
    projectId: "hman-ram212",
    storageBucket: "hman-ram212.appspot.com",
    messagingSenderId: "197246651280",
    appId: "1:197246651280:web:5363d05e3ebda4687a8115",
    measurementId: "G-SE0MDYYGCT"
};

// Initialize Firebase
//const app = initializeApp(firebaseConfig);

let reset = document.querySelector("#reset");
reset.addEventListener("click", function() {
    //const auth = firebase.auth();
    const emailAddress = document.getElementById("reset").value;
    sendPasswordResetEmail(emailAddress)
        .then(() => {
            console.log("Email sent");
        })
        .catch((error) => {
            const errorCode = error.code;
            const errorMessage = error.message;
            // ..
        });
})
