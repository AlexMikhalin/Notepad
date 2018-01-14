$(document).ready(function () {
    GetRecords();
});

$(document).on("click", ".delete", function () {
    var recId = $(this).attr("data-id");
    $.ajax({
        type: "GET",
        url: "/Home/Remove",
        data: {
            id: recId
        }
    }).done(function (msg) {
        GetRecords();
    });
});

$(document).on("click", ".toggle-btn", function () {
    var recId = $(this).attr("data-id");
    $.ajax({
        type: "GET",
        url: "/Home/ToggleNote",
        data: {
            id: recId
        }
    }).done(function (msg) {
        GetRecords();
    });
});

$(document).on("click", ".swap-up", function () {
    var recId = $(this).attr("data-id");
    $.ajax({
        type: "GET",
        url: "/Home/SwapUp",
        data: {
            id: recId
        }
    }).done(function (msg) {
        GetRecords();
    });
});

 
$("#searchButton").click(function () {        //Это фиаско братан
    $.ajax({
        type: "GET",
        url: "/Home/searchString",
        data: {
            Note: $("#search").val()
        }
    }).done(function (msg) {
        $('#records-table').html(msg);
    });
});

$(document).on("click", ".swap-down", function () {
    var recId = $(this).attr("data-id");
    $.ajax({
        type: "GET",
        url: "/Home/SwapDown",
        data: {
            id: recId
        }
    }).done(function (msg) {
        GetRecords();
    });
});


function getsmile() {
    $.ajax({
        type: "POST",
        url: "/Home/Add",
        data: {
           Note: $("#note").val(),
           Sort: $("#number").val(),
           Color: $("#color").val()
        }
    }).done(function (msg) {
        $('#adder').text('Запись добавлена')
        GetRecords();
    });
};
function GetRecords() {
    $.ajax({
        type: "GET",
        url: "/Home/_RecordsPartial"
    }).done(function (data) {
        $('#records-table').html(data)
    });
};




