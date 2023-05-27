
const auth = firebase.auth();
const ResetPasswordFunction = () => {
    const emailAddress = document.getElementById("emailAddress").value;
    auth.sendPasswordResetEmail(emailAddress).then(() => {
            console.log("Email sent");
        })
        .catch((error) => {
            console.log(error);
        })
})

ResetPasswordFunction.AddEventListener("click", (event) => {
    ResetPasswordFunction();
});