function downloadScreenShot(filename) {
    var element = document.querySelector("#stat-card");
    html2canvas(element, {
        backgroundColor: "#1e1e1e",
        useCORS: true,
        scale: 2,
        logging: false
    }).then(canvas => {
        saveAs(canvas.toDataURL('image/png'), filename + '.png');
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