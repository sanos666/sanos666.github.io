function downloadScreenShot(filename) {
    html2canvas(document.querySelector("#SelectedPlayerInfo")).then(canvas => {
        saveAs(canvas.toDataURL(), filename + '.png')
    });
}


function saveAs(uri, filename) {
    var link = document.createElement('a');
    if (typeof link.download === 'string') {
        link.href = uri;
        link.download = filename;

        //Firefox requires the link to be in the body
        document.body.appendChild(link);

        //simulate click
        link.click();

        //remove the link when done
        document.body.removeChild(link);
    } else {
        window.open(uri);
    }
}