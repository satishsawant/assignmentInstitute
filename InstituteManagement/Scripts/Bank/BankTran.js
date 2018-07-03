$(document).ready(function () {
    GetAllBankTran();
    GetAllBank();
    
});
var BaseURL = "http://45.35.4.250/institutemgmt/api/";

//Get All Bank Tran
function GetAllBankTran() {
    debugger;
    $.ajax({
        type: "GET",
        url: BaseURL + "Bank/GetAllBankTrn/0",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            //var course = data.success;
            var arr = [];
            arr = data.BankTransList;
            $.each(arr, function (i, item) {
                var options = "<tr><td>" + item.ID + "</td><td>" + item.BankID + "</td><td>" + item.TransactionType + "</td> <td>" + item.Amount + "</td> <td>" + item.DateOfTrn + "</td><td>" + item.TrnDoneBy + "</td></td>";
                $('#banktranbody').append(options);
            }); //End of foreach Loop 
        },
        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    });
}

//Get All Bank
function GetAllBank() {
    debugger;
    $.ajax({
        type: "GET",
        url: BaseURL + "Bank/GetAll/0",
        contentType: "application/json;",
        dataType: "json",
        success: function (data) {
            // alert(data)
            var arr = [];
            arr = data.BankList;
            $.each(arr, function (i, item) {
                var options = "<option class='dropdown-item' value=" + item.ID + ">" + item.BankName + "</option>";
                //var options = "<tr><td>" + item.ID + "</td><td>" + item.BankName + "</td><td>" + item.AccountNumber + "</td><td>" + item.Address + "</td><td>" + item.ContactNumber1 + "</td><td>" + item.ContactNumber2 + "</td><td><p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' data-title='Edit'onclick='setValueForEdit(" + '"' + item.ID + '","' + item.BankName + '","' + item.AccountNumber + '","' + item.Address + '","' + item.ContactNumber1 + '","' + item.ContactNumber2 + '"' + ")' data-toggle='modal' data-target='#edit'><span class='glyphicon glyphicon-pencil'></span></button></p></td><td><p data-placement='top' data-toggle='tooltip' title='Delete'><button class='btn btn-danger btn-xs' data-title='Delete' data-toggle='modal' data-target='#delete'><span class='glyphicon glyphicon-trash'></span></button></p></td>";
                $('#bankname').append(options);
            }); //End of foreach Loop   
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
}

//Create Bank Tran
function CreateBankTran() {
    debugger;
    var banktran = {

        "BankID": $("#bankname").val(),
        "TransactionType": $("#credit").val(),
        "Amount": $("#amount").val(),
        "DateOfTrn": $("#trandate").val(),
        "TrnDoneBy": $("#trandone").val()
       
    };
    $.ajax({
        type: "POST",
        url: BaseURL + "Bank/CreateBankTrn",
        data: JSON.stringify(banktran),
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            alert("Create Succesfully");
        },
        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  
    })
}