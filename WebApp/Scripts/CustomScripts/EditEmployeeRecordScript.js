(function ()
{
    "use strict";

    function EditRequest()
    {
        if ($("#actionEmp").val() != 0)
        {
            var editRecord = {
                recordId: $("#employeeRecordId").text(),
                recordDate: new Date(),
                action: $("#actionEmp option:selected").text(),
                description: $("#description").val(),
                position: $("#position").val(),
                confirmDocument: $("#confirmDocument").val()
            };

            $.ajax({
                type: "post",
                url: "/EditEmployeeRecord/UpdateEmployeeRecord",
                data: JSON.stringify(editRecord),
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

    function DeleteRequest()
    {
        if ($("#actionEmp").val() != 0)
        {
            var deleteEmployeeRecord = {
                recordId: $("#employeeRecordId").text()
            };

            $.ajax({
                type: "post",
                url: "/EditEmployeeRecord/DeleteEmployeeRecord",
                data: JSON.stringify(deleteEmployeeRecord),
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
            EditRequest();
        });

        $("#buttonDelete").click(function ()
        {
            DeleteRequest();
        });
    })
}());