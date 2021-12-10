// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const userAvatar = document.getElementById("userAvatar");
const dropdownMenu = document.getElementById("dropdownMenu");

userAvatar.addEventListener('click', () => {
	userAvatar.classList.toggle("dropdown-trigger-personalNavActive");
	dropdownMenu.classList.toggle("dropdownMenu-Show");
})
