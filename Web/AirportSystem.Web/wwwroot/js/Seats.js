
jQuery(document).ready(function () {

    $('div.seating-chart a.available').bind('click', selecteSeat); {
        function selecteSeat(e) {
            e.preventDefault();
            $('.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    }

});