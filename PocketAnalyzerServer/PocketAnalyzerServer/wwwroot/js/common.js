window.ShowToastr = (type, message) => {
    if (type === "git") {
        toastr.success(message, 'Gitara')
    }
    if (type === 'bad') {
        toastr.error(message, 'Faled fhoy')
    }
}

window.SwalAlert = (type, message, buttonMessage) => {
    if (type === "git") {
        Swal.fire(message, buttonMessage, 'success')
    }
    if (type === 'bad') {
        Swal.fire(message, buttonMessage, 'error')
    }
}

window.SwalOnDelete = (onDeleteMessage) => {
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: onDeleteMessage,
        showConfirmButton: false,
        timer: 1500
    })
}

window.SwalConfirm = () => {
    result = confirm()

    if (result) {
        return true
    }

    return false
}