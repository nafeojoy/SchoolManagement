        window.onload = function () {
            $('.myclass').attr('readonly', true);
        };

$(function () {
    $('a.edit').on("click", function (e) {

        $('.myclass').attr('readonly', false);


        //                e.preventDefault();
        //                var dad = $(this).parent().parent();
        //                var lbl = dad.find('.ccc');
        //                lbl.hide();
        //                dad.find('.myclass').val(lbl.text()).show().focus();
    });




    //            $('.myclass').focusout(function () {
    //                var dad = $(this).parent();
    //                $(this).hide();
    //                dad.find('.ccc').text(this.value).show();
    //            });
});