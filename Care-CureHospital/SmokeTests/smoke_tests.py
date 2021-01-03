import sys
import requests


def smoke_test(url):
    TIMEOUT = 10
    print("Test for end point: " + url)
    try:
        print("Sending request...")
        response = requests.get(url, timeout=TIMEOUT)

        if response.ok:
            print(response)
            print("DB => OK")
            print("WebAPI => OK")
        else:
            raise requests.exceptions.RequestException()

    except requests.exceptions.RequestExceprion as e:
        print(e)
        sys.exit(-1)


if __name__ == "__main__":
    smoke_test('https://carecurehospitalwebapp.herokuapp.com/api/doctor/getAllSpecialization')
    smoke_test('https://carecurehospitalwebapp.herokuapp.com/api/patientFeedback')
