$('#Identity').keypress(function (e) {
    if (e.which === 13) {
        $.ajax(
            {
                url: "http://localhost:32657/Visitor/GetNameByID",
                type: "GET",
                data: { id: $('#Identity').val() }
            }).done(function (data)
            {
                //var nombre = JSON.parse(data);
                console.log(data);
                $('#Name').val(data["FirstName"] + " " + ((data["MiddleName"] === "") ? "" : data["MiddleName"]) + " " + data["FirstLastName"] + " " + data["SecondLastName"]);
            });
    }
});