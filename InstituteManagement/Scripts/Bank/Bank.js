$(document).ready(function () {
    GetAllBank();
});
var BaseURL = "http://45.35.4.250/institutemgmt/api/";

//Get All BAnk
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
                //var options = "<option class='dropdown-item' value=" + item.CourseID + ">" + item.CourseTypeName + "</option>";
                var options = "<tr><td>" + item.ID + "</td><td>" + item.BankName + "</td><td>" + item.AccountNumber + "</td><td>" + item.Address + "</td><td>" + item.ContactNo1 + "</td><td>" + item.ContactNo2 + "</td><td><p data-placement='top' data-toggle='tooltip' title='Edit'><button class='btn btn-primary btn-xs' data-title='Edit'onclick='setValueForEdit(" + '"' + item.ID + '","' + item.BankName + '","' + item.AccountNumber + '","' + item.Address + '","' + item.ContactNo1 + '","' + item.ContactNo2 + '"' + ")' data-toggle='modal' data-target='#edit'><span class='glyphicon glyphicon-pencil'></span></button></p></td>";
                $('#bankbody').append(options);
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

//Create Bank
function CreateBank() {
    debugger;
    var bank = {

        "BankName": $("#bankname").val(),
        "AccountNumber": $("#bankaccountno").val(),
        "Address": $("#bankaddress").val(),
        "ContactNo1": $("#contact1").val(),
        "ContactNo2": $("#contact2").val(),
       
    };
    $.ajax({
        type: "POST",
        url: BaseURL + "Bank/CreateBank",
        data: JSON.stringify(bank),
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

//setValueForEdit
function setValueForEdit(id,name,accno,addr,cont1,cont2) {
    debugger;
    $('#bankid').val(id);
    $('#editbankname').val(name);
    $('#editaccountno').val(accno);
    $('#editaddress').val(addr);
    $('#editcontact1').val(cont1);
    $('#editcontact2').val(cont2);
}

//update Bank
function EditBank() {
    debugger;
    var bank = {
        "ID": $("bankid").val(),
        "BankName": $("#editbankname").val(),
        "AccountNumber": $("#editaccountno").val(),
        "Address": $("#editaddress").val(),
        "ContactNo1": $("#editcontact1").val(),
        "ContactNo2": $("#editcontact2").val()
    };
    $.ajax({
        type: "POST",
        url: BaseURL + "Bank/UpdateBank",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(bank),
        success: function (data) {
            if (data = 'success') { alert('Updated Successfully') }
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
    $('#edit').modal('toggle');
}
