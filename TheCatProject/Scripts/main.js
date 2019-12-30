function pageDetails() {
    document.getElementById("details").innerHTML =
        "<br />" + "Let's make sure things look right" + "<br /><br />" +
        "CHANGE DETAILS to edit" + "<br />" + "CONTINUE to add traits" + "<br />" + "ALL DONE to quit process"
}

function pageDetailsEnd() {
    document.getElementById("details").innerHTML =
        "<br />" + "Let's make sure things look right" + "<br /><br />" +
        "CHANGE DETAILS to edit" + "<br />" + "FINISH to see cat stats"
}

function getStats() {
    selectElement =
        document.querySelector('#select1');

    selection = selectElement.value;

    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Information/StatsQuery",
        data: { 'selection': selection },
        success: showStats,
        error: errorOnAjax
    });
};

function errorOnAjax() {
    console.log("ERROR in ajax request.");
}

//function showStats() {
//    $('output').html(data);
//}

function showStats(data) {
    for (var i = 0; i < data.length; i++) {
        $('#output').append($('<ul>' + data[i] + '</ul>'));
    }
    
}


