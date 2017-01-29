$(document).ready(function () {
    setTimeout("Refresh();", 5000);
});

function Refresh() {
    $.ajax({
        type: 'POST',
        url: 'localhost/Message/NumOfUnread',
        data: $("#userId").val(),
        success: function (data) {
            $("#messageCount").innerHTML = data;
        }
    });
    setTimeout("Refresh();", 5000);
}