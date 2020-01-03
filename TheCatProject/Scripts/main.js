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

    if (selection == "ages") {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: "/Information/StatsQuery",
            data: { 'selection': selection },
            success: showAges,
            error: errorOnAjax
        });
    }
    else if (selection == "colors") {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: "/Information/StatsQuery",
            data: { 'selection': selection },
            success: showColors,
            error: errorOnAjax
        });
    }
    else if (selection == "breeds") {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: "/Information/StatsQuery",
            data: { 'selection': selection },
            success: showBreeds,
            error: errorOnAjax
        });
    }
    else if (selection == "names") {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: "/Information/StatsQuery",
            data: { 'selection': selection },
            success: showNames,
            error: errorOnAjax
        });
    }
    else {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: "/Information/StatsQuery",
            data: { 'selection': selection },
            success: showTraits,
            error: errorOnAjax
        });
    }
};

function errorOnAjax() {
    console.log("ERROR in ajax request.");
}

function showAges(data) {

    document.getElementById("output").remove();
    $('#outputTable').append($('<table id=\"output\">'));
    $('#output').append($('<tr id=\"tableTr\">'));
    $('#tableTr').append($('<th><strong><center> All Age Submissions </th>'));
    $('#output').append($('</tr>'));
    $('#outputTable').append($('</table>'));
     
    for (var i = data.length - 1; i >= 0; i--) {
        var table = document.getElementById("output");
        var row = table.insertRow(1);
        var cell = row.insertCell(0);
        cell.innerHTML = '<center>' + data[i];
    }
}

function showBreeds(data) {
    document.getElementById("output").remove();
    $('#outputTable').append($('<table id=\"output\">'));
    $('#output').append($('<tr id=\"tableTr\">'));
    $('#tableTr').append($('<th><strong><center> All Breed Submissions </th>'));
    $('#output').append($('</tr>'));
    $('#outputTable').append($('</table>'));

    for (var i = data.length - 1; i >= 0; i--) {
        var table = document.getElementById("output");
        var row = table.insertRow(1);
        var cell = row.insertCell(0);
        cell.innerHTML = '<center>' + data[i].Breeds;
    }
}

function showColors(data) {
    document.getElementById("output").remove();
    $('#outputTable').append($('<table id=\"output\">'));
    $('#output').append($('<tr id=\"tableTr\">'));
    $('#tableTr').append($('<th><strong><center> All Color Submissions </th>'));
    $('#output').append($('</tr>'));
    $('#outputTable').append($('</table>'));

    for (var i = data.length - 1; i >= 0; i--) {
        var table = document.getElementById("output");
        var row = table.insertRow(1);
        var cell = row.insertCell(0);
        cell.innerHTML = '<center>' + data[i].Colors;
    }
}
function showNames(data) {
    document.getElementById("output").remove();
    $('#outputTable').append($('<table id=\"output\">'));
    $('#output').append($('<tr id=\"tableTr\">'));
    $('#tableTr').append($('<th><strong><center> All Name Submissions </th>'));
    $('#output').append($('</tr>'));
    $('#outputTable').append($('</table>'));

    for (var i = data.length - 1; i >= 0; i--) {
        var table = document.getElementById("output");
        var row = table.insertRow(1);
        var cell = row.insertCell(0);
        cell.innerHTML = '<center>' + data[i];
    }
}

function showTraits(data) {
    document.getElementById("output").remove();
    $('#outputTable').append($('<table id=\"output\">'));
    $('#output').append($('<tr id=\"tableTr\">'));
    $('#tableTr').append($('<th><strong><center> All Traits Submissions </th>'));
    $('#output').append($('</tr>'));
    $('#outputTable').append($('</table>'));

    for (var i = data.length - 1; i >= 0; i--) {
        var table = document.getElementById("output");
        var row = table.insertRow(1);
        var cell = row.insertCell(0);
        cell.innerHTML = '<center>' + data[i].Traits;
    }
}


