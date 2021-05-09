from pydub import AudioSegment, effects

# audios = ['Ambience', 'SlidingDoor', 'WoodDoor']

# for audio in audios:
rawsound = AudioSegment.from_file(f'./steps.wav', "wav")
normalizedsound = effects.normalize(rawsound)
normalizedsound.export(f'./steps.wav', format="wav")
