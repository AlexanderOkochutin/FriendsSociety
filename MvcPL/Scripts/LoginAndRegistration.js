$(".datepicker").datepicker({
        dateFormat: 'd M yy',
        changeMonth: true,
        changeYear: true,
        yearRange: "-100:+0"
    });

$('.message a').click(function() {
    $('fieldset').animate({ height: "toggle", opacity: "toggle" }, "slow");
});