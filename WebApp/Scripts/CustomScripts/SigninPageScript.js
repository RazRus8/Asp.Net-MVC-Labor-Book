(function ()
{
    "use strict";

    function SendRequest()
    {
        var user = { username: $("#inputUsername").val(), password: $("#inputPassword").val() };

        $.ajax({
            type: "post",
            url: "/Signin/Validate",
            data: JSON.stringify(user),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response)
            {
                if (response.success)
                {
                    window.location.href = "/MainPage/Index";
                }
                else
                {
                    alert("Incorrect username or password");
                    $("#inputUsername").val("");
                    $("#inputPassword").val("");
                    SetFocus();
                }
            }
        });
    }

    function SetFocus()
    {
        $("#inputUsername").focus();
    }

    $(document).ready(function ()
    {
        SetFocus();
    });
}());