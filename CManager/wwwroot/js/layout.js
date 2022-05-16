function hideLoginForm() {
    var loginForm = document.getElementById("loginForm");
    loginForm.classList.remove("is-loaded");
}
function showLoginForm() {
    hideRegisterForm();
    var loginForm = document.getElementById("loginForm");
    loginForm.classList.add("is-loaded");
}
function hideRegisterForm() {
    var loginForm = document.getElementById("registerForm");
    loginForm.classList.remove("is-loaded");
}
function showRegisterForm() {
    hideLoginForm();
    var loginForm = document.getElementById("registerForm");
    loginForm.classList.add("is-loaded");
}