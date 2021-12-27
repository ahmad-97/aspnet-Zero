(function() {
    $(function() {
        var _$governatatesTable = $('#GovernatatesTable');
        var _governatatesService = abp.services.app.governatates;
        $('.date-picker').datetimepicker({
            locale: abp.localization.currentLanguage.name,
            format: 'L'
        });
        var _permissions = {
            create: abp.auth.hasPermission('Pages.Governatates.Create'),
            edit: abp.auth.hasPermission('Pages.Governatates.Edit'),
            'delete': abp.auth.hasPermission('Pages.Governatates.Delete')
        };
        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/Governatates/CreateOrEditModal',
            scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/Governatates/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditGovernatateModal'
        });
        var _viewGovernatateModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/Governatates/ViewgovernatateModal',
            modalClass: 'ViewGovernatateModal'
        });
        var getDateFilter = function(element) {
            if (element.data("DateTimePicker").date() == null) {
                return null;
            }
            return element.data("DateTimePicker").date().format("YYYY-MM-DDT00:00:00Z");
        }
        var getMaxDateFilter = function(element) {
            if (element.data("DateTimePicker").date() == null) {
                return null;
            }
            return element.data("DateTimePicker").date().format("YYYY-MM-DDT23:59:59Z");
        }
        var dataTable = _$governatatesTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _governatatesService.getAll,
                inputFilter: function() {
                    return {
                        filter: $('#GovernatatesTableFilter').val(),
                        codeFilter: $('#codeFilterId').val(),
                        nameFilter: $('#NameFilterId').val()
                    };
                }
            },
            columnDefs: [{
                    className: 'control responsive',
                    orderable: false,
                    render: function() {
                        return '';
                    },
                    targets: 0
                },
                {
                    width: 120,
                    targets: 1,
                    data: null,
                    orderable: false,
                    autoWidth: false,
                    defaultContent: '',
                    rowAction: {
                        cssClass: 'btn btn-brand dropdown-toggle',
                        text: '<i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span>',
                        items: [{
                                text: app.localize('View'),
                                iconStyle: 'far fa-eye mr-2',
                                action: function(data) {
                                    _viewGovernatateModal.open({
                                        id: data.record.governatate.id
                                    });
                                }
                            },
                            {
                                text: app.localize('Edit'),
                                iconStyle: 'far fa-edit mr-2',
                                visible: function() {
                                    return _permissions.edit;
                                },
                                action: function(data) {
                                    _createOrEditModal.open({
                                        id: data.record.governatate.id
                                    });
                                }
                            },
                            {
                                text: app.localize('Delete'),
                                iconStyle: 'far fa-trash-alt mr-2',
                                visible: function() {
                                    return _permissions.delete;
                                },
                                action: function(data) {
                                    deleteGovernatate(data.record.governatate);
                                }
                            }
                        ]
                    }
                },
                {
                    targets: 2,
                    data: "governatate.code",
                    name: "code"
                },
                {
                    targets: 3,
                    data: "governatate.name",
                    name: "name"
                }
            ]
        });

        function getGovernatates() {
            dataTable.ajax.reload();
        }

        function deleteGovernatate(governatate) {
            abp.message.confirm(
                '',
                app.localize('AreYouSure'),
                function(isConfirmed) {
                    if (isConfirmed) {
                        _governatatesService.delete({
                            id: governatate.id
                        }).done(function() {
                            getGovernatates(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        }
        $('#ShowAdvancedFiltersSpan').click(function() {
            $('#ShowAdvancedFiltersSpan').hide();
            $('#HideAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideDown();
        });
        $('#HideAdvancedFiltersSpan').click(function() {
            $('#HideAdvancedFiltersSpan').hide();
            $('#ShowAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideUp();
        });
        $('#CreateNewGovernatateButton').click(function() {
            _createOrEditModal.open();
        });
        $('#ExportToExcelButton').click(function() {
            _governatatesService
                .getGovernatatesToExcel({
                    filter: $('#GovernatatesTableFilter').val(),
                    codeFilter: $('#codeFilterId').val(),
                    nameFilter: $('#NameFilterId').val()
                })
                .done(function(result) {
                    app.downloadTempFile(result);
                });
        });
        abp.event.on('app.createOrEditGovernatateModalSaved', function() {
            getGovernatates();
        });
        $('#GetGovernatatesButton').click(function(e) {
            e.preventDefault();
            getGovernatates();
        });
        $(document).keypress(function(e) {
            if (e.which === 13) {
                getGovernatates();
            }
        });
    });
})();