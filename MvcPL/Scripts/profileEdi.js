$("input#city").autocomplete({
    source: function (request, response) {
        jQuery.getJSON(
           "http://gd.geobytes.com/AutoCompleteCity?callback=?&q=" + request.term,
           function (data) {
               response(data);
           }
        );
    },
    minLength: 3
});

$(".datepicker").datepicker({
    dateFormat: 'd M yy',
    changeMonth: true,
    changeYear: true,
    yearRange: "-100:+0"
});