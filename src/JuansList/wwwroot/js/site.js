﻿$(document).ready(function () {
    $('.carousel').carousel(
        { dist: -50}
        );

    $('select').material_select();


    $("#catAdd").on("click", function (e) {
        $.ajax({
            url: `/Vendor/AddCat`,
            data: JSON.stringify($("#CatListing").val()),
            method: "POST",
            dataType: "json",
            contentType: 'application/json; charset=utf-8'
        }).done(() => {
            location.reload();
        });
    });

});