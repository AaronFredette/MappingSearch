
$(document).ready(function () {
    $("#logoutButton").on("click", function () {
        $.ajax({
            url: "/Account/Logout",
            type: "POST",
            success: function () { window.location = "/";}
        });
    });

    $(".capitalize").each(function () {
        $(this).text($(this).text().charAt(0).toUpperCase() + $(this).text().slice(1).toLowerCase());//split on white space and cap each first letter 
    });
});