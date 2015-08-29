$(function () {
    if ($('div[data-gridname="allPlayersGrid"]').length)
    {
        pageGrids.allPlayersGrid.onRowSelect(function (e) {
            // Flip the hidden checkbox
            var checkBox = $('#CheckBox' + e.row.Id);
            // Get closest row to checkbox
            var selectedRow = checkBox.closest('tr');
            if (selectedRow.hasClass('grid-row-selected')) {
                selectedRow.removeClass('grid-row-selected');
                checkBox.prop("checked", false);
            }
            else {
                selectedRow.addClass('grid-row-selected');
                checkBox.prop("checked", true);
            }
        });
    }
});