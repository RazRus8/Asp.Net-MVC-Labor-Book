(function ()
{
    "use strict";

    function DayInitializer()
    {
        for (var i = 1; i < 32; i++)
        {
            $("#dayBirth").append($("<option />").val(i).text(i));
        }
    }

    function MonthInitializer()
    {
        var months = {
            0: "January",
            1: "February",
            2: "March",
            3: "April",
            4: "May",
            5: "June",
            6: "July",
            7: "August",
            8: "September",
            9: "October",
            10: "November",
            11: "December"
        };

        for (var index in months)
        {
            $("#monthBirth").append($("<option />").val(index).text(months[index]));
        }
    }

    function YearInitializer()
    {
        for (var i = 1950; i < 2002; i++)
        {
            $("#yearBirth").append($("<option />").val(i).text(i));
        }
    }

    function EditRequest()
    {
        var day = $("#dayBirth option:selected").val();
        var month = $("#monthBirth option:selected").val();
        var year = $("#yearBirth option:selected").val();

        var newEmployee = {
            employeeId: $("#employeeId").text(),
            firstname: $("#firstName").val(),
            lastname: $("#lastName").val(),
            patronymic: $("#patronymic").val(),
            birthday: new Date(year, month, day),
            educationLevel: $("#education option:selected").text(),
            educationDegree: $("#educationDegree").val(),
            registrationDate: new Date()
        };

        $.ajax({
            type: "post",
            url: "/EditEmployee/UpdateEmployee",
            data: JSON.stringify(newEmployee),
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

    function DeleteRequest()
    {
        var deleteEmployee = {
            employeeId: $("#employeeId").text()
        };

        $.ajax({
            type: "post",
            url: "/EditEmployee/DeleteEmployee",
            data: JSON.stringify(deleteEmployee),
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

    function SetFocus()
    {
        $("#firstName").focus();
    }

    $(document).ready(function ()
    {
        DayInitializer();
        MonthInitializer();
        YearInitializer();

        SetFocus();

        $("#buttonOk").click(function ()
        {
            EditRequest();
        });

        $("#buttonDelete").click(function ()
        {
            DeleteRequest();
            //alert("Work in progress!");
        });
    })
}());