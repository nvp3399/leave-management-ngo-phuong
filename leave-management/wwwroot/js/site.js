// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#tblData').DataTable();
});

$(document).ready(function () {
    $("table[id^='TABLE']").DataTable({
        "scrollY": "1000px",
        "scrollCollapse": true,
        "searching": true,
        "paging": true
    });
});