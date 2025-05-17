
$(function () {
    $('#ancrLogout').click(function () {
        $('#logout_form').submit();
    });
    $('#ancrResetPassword').click(function () {
        $('#resetPassword_form').submit();
    });
});
$(document).ready(function () {
    $('.collapsible').collapsible();
});
