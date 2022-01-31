window.ShowToastr = (type, message) => {
    if (type === "git") {
        toastr.success(message, 'Gitara')
    }
    if (type === 'bad') {
        toastr.error(message, 'Faled fhoy')
    }
}