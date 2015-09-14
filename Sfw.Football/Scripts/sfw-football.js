$(function () {
    if ($('div[data-gridname="allPlayersGrid"]').length) {
        // Apply css to any selected rows (i.e. when selection is pre-populated)
        $('.SelectPlayerCheckBox').each(function () {
            if (this.checked) {
                var row = $(this).closest('tr');
                if (!row.hasClass('grid-row-selected')) {
                    row.addClass('grid-row-selected');
                }
            }
        });

        // Add function to onRowSelect to apply css to rows
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