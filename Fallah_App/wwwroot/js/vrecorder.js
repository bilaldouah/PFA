// collect DOMs
const display = document.querySelector('.display')
const controllerWrapper = document.querySelector('.controllers')
const fileInput = document.querySelector('#fileInput');

const State = ['Initial', 'Record', 'Download']
let stateIndex = 0
let mediaRecorder, chunks = [], audioURL = ''

// mediaRecorder setup for audio
if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
    console.log('mediaDevices supported..')

    navigator.mediaDevices.getUserMedia({
        audio: true
    }).then(stream => {
        mediaRecorder = new MediaRecorder(stream)

        mediaRecorder.ondataavailable = (e) => {
            chunks.push(e.data)
        }

        mediaRecorder.onstop = () => {
            const blob = new Blob(chunks, { 'type': 'audio/ogg; codecs=opus' })
           // chunks = []
            audioURL = window.URL.createObjectURL(blob)
            document.querySelector('audio').src = audioURL

        }
    }).catch(error => {
        console.log('Following error has occured : ', error)
    })
} else {
    stateIndex = ''
    application(stateIndex)
}

const clearDisplay = () => {
    display.textContent = ''
}

const clearControls = () => {
    controllerWrapper.textContent = ''
}

const record = () => {
    stateIndex = 1
    mediaRecorder.start()
    application(stateIndex)
}

const stopRecording = () => {
    stateIndex = 2
    mediaRecorder.stop()
    application(stateIndex)
}

const downloadAudio = () => {
    const downloadLink = document.createElement('a')
    downloadLink.href = audioURL
    downloadLink.setAttribute('download', 'audio.ogg')
    downloadLink.click()

}

const uploadAudio = () => {
    const file = new File([chunks[0]], 'audio.ogg', { type: 'audio/ogg' });
    const dataTransfer = new DataTransfer();
    dataTransfer.items.add(file);
    fileInput.files = dataTransfer.files;
};

const addButton = (id, funString, text, colorClass,nokita) => {
    const btn = document.createElement('button');
    btn.id = id;
    btn.setAttribute('onclick', funString);
    btn.textContent = text;
    btn.classList.add('btn','waves-effect',colorClass,nokita); // Add Bootstrap classes
    controllerWrapper.append(btn);
};


const addMessage = (text) => {
    const msg = document.createElement('p');
    msg.textContent = text;

        msg.classList.add('recording'); // Add animation classes from animate.css

    display.append(msg);
};

const addAudio = () => {
    const audio = document.createElement('audio')
    audio.controls = true
    audio.src = audioURL
    display.append(audio)
}

const application = (index) => {
    switch (State[index]) {
        case 'Initial':
            clearDisplay();
            clearControls();

            addButton('record', 'record()', 'Start Recording', 'btn-success','notika-btn-success'); // Add green color class
            break;

        case 'Record':
            clearDisplay();
            clearControls();

            addMessage('Recording...'); // Apply animation
            addButton('stop', 'stopRecording()', 'Stop Recording', 'btn-warning','notika-btn-warning'); // Add yellow color class
            break;

        case 'Download':
            clearControls();
            clearDisplay();

            addAudio();
            addButton('record', 'record()', 'Record Again', 'btn-success','notika-btn-success'); // Add green color class
            addButton('download', 'downloadAudio()', 'Download Audio', 'btn-primary','notika-btn-primary'); // Add custom design class
            addButton('upload', 'uploadAudio()', 'Upload Audio', 'btn-info','notika-btn-info'); // Add custom design class
            break;

        default:
            clearControls();
            clearDisplay();

            addMessage('Your browser does not support mediaDevices');
            break;
    }
};






application(stateIndex)


