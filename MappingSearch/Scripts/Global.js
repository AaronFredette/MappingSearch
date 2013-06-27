
$(document).ready(function () {
    $("#logoutButton").on("click", function () {
        $.ajax({
            url: "/Account/Logout",
            type: "POST",
            success: function () { window.location = "/";}
        });
    });
});