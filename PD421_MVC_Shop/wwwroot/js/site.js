// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var pageModal = null;

function openModal(id) {
    var link = document.getElementById("deleteCategoryAction");
    link.href = "/Category/Delete/" + id;
    pageModal = new bootstrap.Modal(document.getElementById("categoryDeleteModal"), { keyboard: false });
    pageModal.show();
}

function closeModal() {
    if (pageModal != null) {
        pageModal.hide();
        pageModal = null;
    }
}