// AJAX Call for Counter Increment
$(document).ready(function () {
    $('#incrementCounterForm').on('submit', function (e) {
        e.preventDefault();
        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (result) {
                $('#counterPartial').html(result);
            },
            error: function () {
                alert('An error occurred retrieving the counter value.');
            }
        });
    });
});

// AJAX Call for String Reverse
$(document).ready(function () {
    $('#reverseStringForm').on('submit', function (e) {
        e.preventDefault();
        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (result) {
                $('#reverseStringPartial').html(result);
            },
            error: function () {
                alert('An error occurred while attempting to reverse string value.');
            }
        });
    });
});