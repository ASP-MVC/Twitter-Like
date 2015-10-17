$(document).ready(function() {
    $(document).click(function(e) {
        if (e.target.id != "retweetBtn") {
            if (!$(event.target).closest("#retweetContainer").length) {
                if ($("#retweetContainer").is(":visible")) {
                    $("#retweetContainer").hide();
                }
            }
        }
    });

    $(document).click(function(e) {
        if (e.target.id != "addTweetBtn") {
            if (!$(event.target).closest("#addTweetContainer").length) {
                if ($("#addTweetContainer").is(":visible")) {
                    $("#addTweetContainer").hide();
                }
            }
        }
    });

   
});

$("#closeGetUsersWindow").click( function () {
    $("#allUsers").toggle();
    $("#closeGetUsersWindow").toggle();
});

function ShowUsersContainer() {
    $("#allUsers").show();
    $("#closeGetUsersWindow").show();
}

function OnAjaxRequestCompleteShowRetweet() {
    $("#retweetContainer").show();
}

function OnAjaxRequestCompleteShowAdd() {
    $("#addTweetContainer").show();
}