from pydub import AudioSegment, effects

audios = ['Ambience', 'SlidingDoor', 'WoodDoor']

for audio in audios:
    rawsound = AudioSegment.from_file(f'./{audio}.wav', "wav")
    normalizedsound = effects.normalize(rawsound)
    normalizedsound.export(f'./normalized{audio}.wav', format="wav")
