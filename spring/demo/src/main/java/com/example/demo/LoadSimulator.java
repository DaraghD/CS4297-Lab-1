package com.example.demo;

import java.net.URI;
import java.net.http.*;
import java.util.stream.IntStream;

public class LoadSimulator {
    public static void main(String[] args) throws Exception {
        HttpClient client = HttpClient.newHttpClient();

        IntStream.range(0, 5000).forEach(i -> {
            new Thread(() -> {
                try {
                    HttpRequest request = HttpRequest.newBuilder()
                            .uri(URI.create("http://localhost:8080/hello"))
                            .build();
                    HttpResponse<String> response =
                            client.send(request, HttpResponse.BodyHandlers.ofString());
                    System.out.println(response.body());
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }).start();
        });
    }
}