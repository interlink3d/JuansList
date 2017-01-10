$(document).ready(function () {
    $('.carousel').carousel(
        { dist: -20 }

        );

    $('select').material_select();


    function catt() {
        return new Promise(function (resolve, reject) {
            $.ajax({
                url: `/Vendor/AddCat`,
                data: JSON.stringify($("#CatListing").val()),
                method: "POST",
                dataType: "json",
                contentType: 'application/json; charset=utf-8'
            }).done((n) => {
                resolve(n)
            }).error(function (err) {
                reject(err)
            })

        })
    }

    $("#catAdd").on("click", function (e) {
        catt().then(function () {
            window.location = `/Vendor/Profile`
        })
    });

    $("listcat").on("change", function (e) {
        $.ajax({
            url: `/Customer/Search/${$(this).val()}`,
            method: "POST",
            dataType: "json",
            contentType: 'application/json; charset=utf-8'
        }).done((n) => {
            })
    })

});