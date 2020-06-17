function AjaxCall(url, data, type) {
    return $.ajax({
        url: url,
        async: false,
        type: type ? type : 'GET',
        data: data,
        contentType: 'application/json'
    });
}


function AjaxFillDropdown(URl,Id,AppendId) {
    if (Id != null && Id != "") {
        var obj = { Id: Id };
        AjaxCall(URl, JSON.stringify(obj), 'POST').done(function (response) {
            $('#' + AppendId).html('');
            var options = '';
            options += '<option value="">--Select--</option>';
            if (response.length > 0) {
                for (var i = 0; i < response.length; i++) {

                    options += '<option value="' + response[i].Key + '">' + response[i].Value + '</option>';
                }
            }
            $('#' + AppendId).append(options);
        }).fail(function (error) {
            alert(error.StatusText);
        });
    }
    else {
        $('#' + AppendId).html('');
        var options = '';
        options += '<option value="Select">--Select--</option>';
        $('#' + AppendId).append(options);
    }
}