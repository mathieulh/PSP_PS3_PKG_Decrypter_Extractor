# PSP_PS3_PKG_Decrypter_Extractor
PSP_PS3_PKG_Decrypter_Extractor

PSP PS3 PKG Decrypter Extractor v.1.0.0.0 by Mathieulh

- What does this do ?
This will decrypt and extract Playstation 3, Playstation Portable and mixed GAME PACKAGES (NOT UPDATER ONES !) onto your pc.


How do I use it ?

Just open the package you want to extract or drag and drop it and click on "Extract package"

Can I run this on Linux ? 

Sorry this app is windows only, however full sources have been supplied along with it so feel
free to make a Linux port out of it, you have my blessing.

Can This encrypt/sign my game packages ? 

NO, when this application was written, the main concern was about packages decryption, so that part
was kinda skipped, however it is trivial to do the reverse operation, remember, sources are supplied.

--------------


Here is the little story, this little app was done since litterally AGES , distributed to a very small amount of people, 
and was conveniently designed and used to decrypt packages and repack them on our debug consoles so we wouldn't
have to QA flag them to update our games or install games we purchased from the ps store. 
The algorithm was a bit of a pain to reverse but the keys could be easily grabbed with a
lv2 exploit. So here we are, this app was done but the problem is it couldn't be leaked because 
I and a few other people who were entrusted with it, were kinda afraid that sony would change the
keys and fix whatever exploits we had (turned out they didn't) but since we can now get whatever
new keys they add/change this has become a quite irrelevant concern. The next concern was piracy.
There was nothing at the time justifying a release for that application, most people would just 
not have a legit use for it so releasing was out of the question.

So what changed our minds ?  Well, ccc happened, and Segher (props to him !) figured how to 
conveniently calculate private keys and suddenly a legit use appeared, as people would/might need
to encrypt their packages to install their own signed apps onto their consoles.
This is not a 1:1 algorithm port as it's been improved, thus the decryption happens 3 times as 
fast as on playstation 3.

Since people suddenly became interested in the game packages format, we just thought releasing that
app would spare them the (hours of) work of reversing the encryption algorithm and that this code
would not go to waste.



Special thanks to someone who helped a lot but whishes to remain anonymous. 

Greetings to Segher whom, I believe people tend to forget too often.


--Mathieulh.

p.s. Forgot to enable the button in vs prior recompile, this is now fixed.
