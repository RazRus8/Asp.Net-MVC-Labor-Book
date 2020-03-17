(function ()
{
    "use strict";

    function Request()
    {
        if ($("#actionEmp").val() != 0)
        {
            var newRecord = {
                employeeId: $("#employeeId").text(),
                recordDate: new Date(),
                action: $("#actionEmp option:selected").text(),
                description: $("#description").val(),
                position: $("#position").val(),
                confirmDocument: $("#confirmDocument").val()
            };

            $.ajax({
                type: "post",
                url: "/AddEmployeeRecord/InsertRecord",
                data: JSON.stringify(newRecord),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (response)
                {
                    if (response.success)
                    {
                        window.location.href = "/MainPage/Index";
                    }
                },
                error: function (xhr, ajaxOptions, thrownError)
                {
                    alert(xhr.status);
                    alert(xhr.responseText);
                    alert(thrownError);
                }
            });
        }
    }

    $(document).ready(function ()
    {
        $("#buttonOk").click(function ()
        {
            Request();
        });
    });
}());