(function($) {
    app.modals.GovernatateLookupTableModal = function() {
        var _modalManager;
        var _citiesService = abp.services.app.cities;
        var _$governatateTable = $('#GovernatateTable');
        this.init = function(modalManager) {
            _modalManager = modalManager;
        };
        var dataTable = _$governatateTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _citiesService.getAllGovernatateForLookupTable,
                inputFilter: function() {
                    return {
                        filter: $('#GovernatateTableFilter').val()
                    };
                }
            },
            columnDefs: [{
                    targets: 0,
                    data: null,
                    orderable: false,
                    autoWidth: false,
                    defaultContent: "<div class=\"text-center\"><input id='selectbtn' class='btn btn-success' type='button' width='25px' value='" + app.localize('Select') + "' /></div>"
                },
                {
                    autoWidth: false,
                    orderable: false,
                    targets: 1,
                    data: "displayName"
                }
            ]
        });
        $('#GovernatateTable tbody').on('click', '[id*=selectbtn]', function() {
            var data = dataTable.row($(this).parents('tr')).data();
            _modalManager.setResult(data);
            _modalManager.close();
        });

        function getGovernatate() {
            dataTable.ajax.reload();
        }
        $('#GetGovernatateButton').click(function(e) {
            e.preventDefault();
            getGovernatate();
        });
        $('#SelectButton').click(function(e) {
            e.preventDefault();
        });
        $(document).keypress(function(e) {
            if (e.which === 13) {
                getGovernatate();
            }
        });
    };
})(jQuery);