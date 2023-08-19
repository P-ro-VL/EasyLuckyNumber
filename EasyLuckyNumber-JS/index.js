const segments = [];

const availableBackground = [
  '#d0ad61',
  '#f46539',
  '#B98473',
  '#EDE9D0',
  '#FF7E6D',
  '#FF9C9F',
  '#FFBDD0',
  '#FFD29D',
  '#BE360E',
];

addEventListener('keydown', (event) => {
  if (event.keyCode == 82) {
    // R - Reset
    resetWheel();
  } else if (event.keyCode == 32) {
    // Space - Spin
    startSpin();
  } else if (event.keyCode == 70) {
    // F - File Selector
    document.getElementById('inputfile').click();
    document
      .getElementById('inputfile')
      .addEventListener('change', function () {
        var fr = new FileReader();
        fr.onload = function () {
          let data = fr.result;
          data.split('\n').forEach((element) => {
            var item =
              availableBackground[
                Math.floor(Math.random() * availableBackground.length)
              ];

            segments.push({ fillStyle: item, text: element });
          });

          init(segments);
        };

        fr.readAsText(this.files[0]);
      });
  }
});

let theWheel = null;
function init(segments) {
  // Create new wheel object specifying the parameters at creation time.
  theWheel = new Winwheel({
    outerRadius: 212, // Set outer radius so wheel fits inside the background.
    innerRadius: 75, // Make wheel hollow so segments don't go all way to center.
    textFontSize: 24, // Set default font size for the segments.
    textOrientation: 'vertical', // Make text vertial so goes down from the outside of wheel.
    textAlignment: 'outer', // Align text to outside of wheel.
    numSegments: segments.length, // Specify number of segments.
    // Define segments including colour and text.
    segments: segments,
    // Specify the animation to use.
    animation: {
      type: 'spinToStop',
      duration: 10, // Duration in seconds.
      spins: 3, // Default number of complete spins.
      callbackFinished: alertPrize,
      soundTrigger: 'pin', // Specify pins are to trigger the sound, the other option is 'segment'.
    },
    // Turn pins on.
    pins: {
      number: 24,
      fillStyle: 'silver',
      outerRadius: 4,
    },
  });
}

// Vars used by the code in this page to do power controls.
let wheelPower = 2;
let wheelSpinning = false;

// -------------------------------------------------------
// Click handler for spin button.
// -------------------------------------------------------
function startSpin() {
  // Ensure that spinning can't be clicked again while already running.
  if (wheelSpinning == false) {
    // Based on the power level selected adjust the number of spins for the wheel, the more times is has
    // to rotate with the duration of the animation the quicker the wheel spins.
    if (wheelPower == 1) {
      theWheel.animation.spins = 3;
    } else if (wheelPower == 2) {
      theWheel.animation.spins = 6;
    } else if (wheelPower == 3) {
      theWheel.animation.spins = 10;
    }

    // Begin the spin animation by calling startAnimation on the wheel object.
    theWheel.startAnimation();

    // Set to true so that power can't be changed and spin button re-enabled during
    // the current animation. The user will have to reset before spinning again.
    wheelSpinning = true;
  }
}

// -------------------------------------------------------
// Function for reset button.
// -------------------------------------------------------
function resetWheel() {
  theWheel.stopAnimation(false); // Stop the animation, false as param so does not call callback function.
  theWheel.rotationAngle = 0; // Re-set the wheel angle to 0 degrees.
  theWheel.draw(); // Call draw to render changes to the wheel.

  wheelSpinning = false; // Reset to false to power buttons and spin can be clicked again.
}

// -------------------------------------------------------
// Called when the spin animation has finished by the callback feature of the wheel because I specified callback in the parameters.
// -------------------------------------------------------
function alertPrize(indicatedSegment) {
  if (indicatedSegment.text == 'LOOSE TURN') {
    alert('Sorry but you loose a turn.');
  } else if (indicatedSegment.text == 'BANKRUPT') {
    alert('Oh no, you have gone BANKRUPT!');
  } else {
    alert('You have won ' + indicatedSegment.text);
  }
}

// Draggable Canvas
// listen for mouse events
let canvas = document.getElementById('canvas');
canvas.style.position = 'absolute';
canvas.style.top = '0px';
canvas.style.left = '0px';
addEventListener('keydown', (e) => {
  if (e.keyCode == 40) {
    canvas.style.top = parseInt(canvas.style.top.replace('px', '')) + 10;
  } else if (e.keyCode == 38) {
    canvas.style.top = parseInt(canvas.style.top.replace('px', '')) - 10;
  } else if (e.keyCode == 39) {
    canvas.style.left = parseInt(canvas.style.left.replace('px', '')) + 10;
  } else if (e.keyCode == 37) {
    canvas.style.left = parseInt(canvas.style.left.replace('px', '')) - 10;
  }
});
