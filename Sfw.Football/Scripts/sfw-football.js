$(function () {
    pageGrids.allPlayersGrid.onRowSelect(function (e) {
        // Flip the checkbox
        var checkBox = $('#CheckBox' + e.row.Id);
        checkBox.prop("checked", !checkBox.prop("checked"));
        // Get closest row to checkbox
        var selectedRow = checkBox.closest('tr');
        // Toggle class on row
        selectedRow.toggleClass("grid-row-selected");
    });
});