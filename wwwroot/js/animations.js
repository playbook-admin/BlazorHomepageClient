function triggerAnimation(elementId, animationClass) {
  const element = document.getElementById(elementId);
  if (element) {
    element.classList.add(animationClass);
    // Remove class after animation ends
    element.addEventListener('animationend', () => {
      element.classList.remove(animationClass);
    });
  }
}


const triggerKeyframeAnimation = (elementId, animationClass) => {
    // Add specific logic for keyframe animations here
    triggerAnimation(elementId, animationClass);
}
