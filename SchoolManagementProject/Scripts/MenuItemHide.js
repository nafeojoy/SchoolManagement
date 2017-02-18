$(document).ready(function () {
    $('#menu a').click(function () {
        $('#menu #first').hide();
        return false;
    });
    $('.content input.close').click(function () {
        $(this).parent().hide();
    });
});