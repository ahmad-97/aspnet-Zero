(function($) {
    app.modals.CreateOrEditCityModal = function() {
        var _citiesService = abp.services.app.cities;
        var _modalManager;
        var _$cityInformationForm = null;
        var _CitygovernatateLookupTableModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/Cities/GovernatateLookupTableModal',
            scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/Cities/_CityGovernatateLookupTableModal.js',
            modalClass: 'GovernatateLookupTableModal'
        });
        this.init = function(modalManager) {
            _modalManager = modalManager;
            var modal = _modalManager.getModal();
            modal.find('.date-picker').datetimepicker({
                locale: abp.localization.currentLanguage.name,
                format: 'L'
            });
            _$cityInformationForm = _modalManager.getModal().find('form[name=CityInformationsForm]');
            _$cityInformationForm.validate();
        };
        $('#OpenGovernatateLookupTableButton').click(function() {
            var city = _$cityInformationForm.serializeFormToObject();
            _CitygovernatateLookupTableModal.open({
                id: city.governatateId,
                displayName: city.governatateName
            }, function(data) {
                _$cityInformationForm.find('input[name=governatateName]').val(data.displayName);
                _$cityInformationForm.find('input[name=governatateId]').val(data.id);
            });
        });
        $('#ClearGovernatateNameButton').click(function() {
            _$cityInformationForm.find('input[name=governatateName]').val('');
            _$cityInformationForm.find('input[name=governatateId]').val('');
        });
        this.save = function() {
            if (!_$cityInformationForm.valid()) {
                return;
            }
            if ($('#City_GovernatateId').prop('required') && $('#City_GovernatateId').val() == '') {
                abp.message.error(app.localize('{0}IsRequired', app.localize('Governatate')));
                return;
            }
            var city = _$cityInformationForm.serializeFormToObject();
            _modalManager.setBusy(true);
            _citiesService.createOrEdit(
                city
            ).done(function() {
                abp.notify.info(app.localize('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('app.createOrEditCityModalSaved');
            }).always(function() {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);