(function($) {
    app.modals.CreateOrEditGovernatateModal = function() {
        var _governatatesService = abp.services.app.governatates;
        var _modalManager;
        var _$governatateInformationForm = null;
        this.init = function(modalManager) {
            _modalManager = modalManager;
            var modal = _modalManager.getModal();
            modal.find('.date-picker').datetimepicker({
                locale: abp.localization.currentLanguage.name,
                format: 'L'
            });
            _$governatateInformationForm = _modalManager.getModal().find('form[name=GovernatateInformationsForm]');
            _$governatateInformationForm.validate();
        };
        this.save = function() {
            if (!_$governatateInformationForm.valid()) {
                return;
            }
            var governatate = _$governatateInformationForm.serializeFormToObject();
            _modalManager.setBusy(true);
            _governatatesService.createOrEdit(
                governatate
            ).done(function() {
                abp.notify.info(app.localize('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('app.createOrEditGovernatateModalSaved');
            }).always(function() {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);