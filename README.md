This is a proof of concept of how 'AI zero-knowledge proofs' could be implemented.

Examples of use cases for AI zero-knowledge proofs:
1. Have personalized software while insuring sensitive data cannot be leaked.
2. Enable researchers to verify hypotheses based on medical data without accessing personal health information directly
3. Insure the software on your device is benevolent.
4. Insure a person in trust is not being bribed.
5. Insure software operates within your personalized user consents.
6. Verify the authenticity and ethical sourcing of products
7. Financial institutions can prove they are adhering to regulations and not facilitating money laundering

...without risking breach of privacy or intellectual property.

How it aims to work in short:
1. We have a black box (secured by whatever means technology allows us).
2. Bob uploads sensitive data into the black box tied to clearly defined data contracts.
3. AI agents act within the black box bounded by its rules.
4. Alice asks the AI agents questions only answerable within the boundaries of the data contracts.
5. Bob can share 

Limitations:
There are many, this is not a working product in any way, but I will list some major ones.
1. Transpairent or similar software would need to be executed within a type of TEE(Trusted Execution Environment)
1.a For example do we need some type of homomorphic encryption?
2. How to verify the uploaded sensitive data is all encompassing to the relevant contract and not tampered with?
2.a For example there can never be a human in the loop from the beginning where sensitive data is processed, if any sensitive data is ever able to be shown on output readable by a human, we have an attack point outside the bounds of cryptographic protection.
2.b I imagine C2PA and/or similar ideas would be required here too, to reduce the potential for tampering of input devices. 
