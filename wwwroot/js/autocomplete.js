$(function () {
    if ($("#BitkininAdi").length) {
        $("#BitkininAdi").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: '/Admin/Aksesyon/PlantNameAutocomplete',
                    data: { term: request.term },
                    success: function (data) {
                        response(data);
                    }
                });
            },
            minLength: 2
        });
    }
});
