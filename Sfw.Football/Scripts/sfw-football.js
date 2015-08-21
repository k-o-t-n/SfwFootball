//$(document).ready(function ($) {
//    $(".clickable-row").click(function () {
//        var checkBox = $('#' + $(this).data("checkBoxId"));
//        checkBox.prop("checked", !checkBox.prop("checked"));
//    });
//});

$(document).ready(function ($) {
    var test = pageGrids.allPlayersGrid;
});

$(function () {
    pageGrids.allPlayersGrid.onRowSelect(function (e) {
        var checkBox = $('#CheckBox' + e.row.Id);
        checkBox.prop("checked", !checkBox.prop("checked"));
    });
});