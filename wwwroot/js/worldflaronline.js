<script>
    $(function () {
        let timer;
    $('#BitkininAdi').on('input', function () {
        clearTimeout(timer);
    const query = $(this).val().trim();
    if (query.length < 3) {
        $('#suggestions').empty();
    return;
        }
    timer = setTimeout(function () {
        $.ajax({
            url: 'https://list.worldfloraonline.org/matching_rest.php',
            data: { input_string: query },
            dataType: 'json',
            success: function (data) {
                let suggestions = '';
                if (data.match && data.match.full_name_plain) {
                    suggestions += `<a href="#" class="list-group-item list-group-item-action">${data.match.full_name_plain}</a>`;
                }
                if (data.candidates && data.candidates.length > 0) {
                    data.candidates.forEach(function (item) {
                        suggestions += `<a href="#" class="list-group-item list-group-item-action">${item.full_name_plain}</a>`;
                    });
                }
                $('#suggestions').html(suggestions).show();
            },
            error: function () {
                $('#suggestions').empty();
            }
        });
        }, 400);
    });

    // Fill input when suggestion is clicked
    $('#suggestions').on('click', 'a', function (e) {
        e.preventDefault();
    $('#BitkininAdi').val($(this).text());
    $('#suggestions').empty();
    });

    // Hide suggestions when clicking outside
    $(document).on('click', function (e) {
        if (!$(e.target).closest('#BitkininAdi, #suggestions').length) {
        $('#suggestions').empty();
        }
    });
});
</script>