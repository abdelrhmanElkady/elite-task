$(document).ready(function () {

    // delete row funciton
    $("button:contains(Delete selected rows)").click(function() {
        $('tr:has(input[type="checkbox"]:checked)').remove();
        calculateBill();
    });

    var allInputs =  $('table tbody tr td input[type="text"]');
    for (let index = 0; index < allInputs.length; index++) {
        // $(element).bind("keyup change input paste", calculateBill());
        $(allInputs[index]).on("keyup", calculateBill);    
    }

});


function calculateBill(){
    var tableRows = $('table tbody tr:not(:last-child)');
    var netTotal = 0;
    for (let index = 0; index < tableRows.length; index++) {
        let totalElement = tableRows[index].querySelector('td span');
        let quantityAndPrice = tableRows[index].querySelectorAll('td input[type="text"]');
        totalElement.innerHTML = quantityAndPrice[0].value * quantityAndPrice[1].value; 
        netTotal +=parseFloat(totalElement.innerHTML);
    }
    $('table tbody tr:last-child td span').text(netTotal);
};